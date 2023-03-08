import { Component, OnInit, Inject } from "@angular/core";

import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";

import { MatSnackBar } from "@angular/material/snack-bar";

import { MAT_DATE_FORMATS } from "@angular/material/core";
import { minDateValidator } from "../../utils/validators";
import * as moment from "moment";

import { Sucursal } from "src/app/interfaces/sucursal";
import { SucursalService } from "src/app/services/sucursal.service";
import { Moneda } from "src/app/interfaces/moneda";
import { MonedaService } from "src/app/services/moneda.service";

export const MY_FORMATS = {
	parse: {
		dateInput: "DD/MM/YYYY",
	},
	display: {
		dateInput: "DD/MM/YYYY",
		monthYearLabel: "MMM YYYY",
		dateA11yLabel: "LL",
		monthYearA11yLabel: "MMMM YYYY",
	},
};

@Component({
  selector: 'app-dialog-add-edit',
  templateUrl: './dialog-add-edit.component.html',
  styleUrls: ['./dialog-add-edit.component.css'],
  providers: [
    { provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
  ],
})
export class DialogAddEditComponent implements OnInit {
	formSucursal: FormGroup;
	accion: string = "Agregar";
	boton: string = "Guardar";
	listaMonedas: Moneda[] = [];

	constructor(
		private dialog: MatDialogRef<DialogAddEditComponent>,
		private fb: FormBuilder,
		private _snackBar: MatSnackBar,
		private _sucursalService: SucursalService,
		private _monedaService: MonedaService,
		@Inject(MAT_DIALOG_DATA) public dataSucursal: Sucursal,
	) {
		this.formSucursal = this.fb.group({
			id: [""],
			codigo: [
				"",
				[
					Validators.required,
					Validators.pattern("^[0-9]*$"),
					Validators.minLength(4),
				],
			],
			descripcion: ["", [Validators.required, Validators.maxLength(250)]],
			direccion: ["", [Validators.required, Validators.maxLength(250)]],
			identificacion: ["", [Validators.required, Validators.maxLength(50)]],
			moneda: [""],
			fechaCreacion: ["", [Validators.required, minDateValidator(new Date())]],
		});

		this._monedaService.getListaMonedas().subscribe({
			next: (data) => {
				this.listaMonedas = data;
			},
			error: (error) => {
				console.log(error);
			},
		});
	}

	alerta(msg: string, accion: string) {
		this._snackBar.open(msg, accion, {
			horizontalPosition: "end",
			verticalPosition: "top",
			duration: 3000,
		});
	}

	addEditSucursal() {
		const modelo: Sucursal = {
			id: this.formSucursal.value.id,
			codigo: this.formSucursal.value.codigo,
			descripcion: this.formSucursal.value.descripcion,
			direccion: this.formSucursal.value.direccion,
			identificacion: this.formSucursal.value.identificacion,
			idMoneda: this.formSucursal.value.moneda,
			fechaCreacion: moment(this.formSucursal.value.fechaCreacion).format(
				"DD/MM/YYYY HH:mm:ss.sss",
			),
		};

		if (!this.formSucursal.valid) {
			this.alerta("Formulario inválido", "Inválido");
		}

		if (this.dataSucursal === null) {
			this._sucursalService.postSucursal(modelo).subscribe({
				next: () => {
					this.alerta("Sucursal agregada con éxito", "Listo");
					this.dialog.close("creado");
				},
				error: () => {
					this.alerta("Error al agregar sucursal", "Error");
				},
			});
		} else {
			this._sucursalService.putSucursal(modelo).subscribe({
				next: () => {
					this.alerta("Sucursal editada con éxito", "Listo");
					this.dialog.close("editado");
				},
				error: () => {
					this.alerta("Error al editar sucursal", "Error");
				},
			});
		}
	}

	ngOnInit(): void {
		if (this.dataSucursal) {
			this.formSucursal.patchValue({
				id: this.dataSucursal.id,
				codigo: this.dataSucursal.codigo,
				descripcion: this.dataSucursal.descripcion,
				direccion: this.dataSucursal.direccion,
				identificacion: this.dataSucursal.identificacion,
				moneda: this.dataSucursal.idMoneda,
				fechaCreacion: moment(this.dataSucursal.fechaCreacion, "DD/MM/YYYY"),
			});

			this.accion = "Modificar";
			this.boton = "Editar";
		}
	}
}
