import { AfterViewInit, Component, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";

import { Sucursal } from "./interfaces/sucursal";
import { SucursalService } from "./services/sucursal.service";

import { MatSnackBar } from "@angular/material/snack-bar";

import { MatDialog } from "@angular/material/dialog";
import { DialogAddEditComponent } from "./components/dialog-add-edit/dialog-add-edit.component";
import { DialogDeleteComponent } from "./components/dialog-delete/dialog-delete.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit {
	title = "Sucursales Quala";

	displayedColumns: string[] = [
		"codigo",
		"descripcion",
		"direccion",
		"identificacion",
		"moneda",
		"fechaCreacion",
		"acciones",
	];
	dataSource = new MatTableDataSource<Sucursal>();

	constructor(
		private _sucursalService: SucursalService,
		public dialog: MatDialog,
		private _snackBar: MatSnackBar,
	) {}

	ngOnInit() {
		this.listarSucursales();
	}

	@ViewChild(MatPaginator) paginator!: MatPaginator;

	ngAfterViewInit() {
		this.dataSource.paginator = this.paginator;
	}

	listarSucursales() {
		this._sucursalService.getListaSucursales().subscribe({
			next: (data) => {
				this.dataSource.data = data;
			},
			error: (error) => {
				console.log(error);
			},
		});
	}

	eliminarSucursal(dataSucursal: Sucursal) {
		console.log(dataSucursal, "eliminarSucursal");
		this.dialog.open(DialogDeleteComponent, {
				disableClose: true,
				width: "600px",
				data: dataSucursal,
			})
			.afterClosed()
			.subscribe((resultado) => {
				if (resultado === "eliminado") {
					console.log(dataSucursal, "eliminarSucursal");
					this._sucursalService.deleteSucursal(dataSucursal.id).subscribe({
						next: () => {
							this.alerta("Sucursal eliminada", "Eliminado");
							this.listarSucursales();
						},
						error: (error) => {
							console.log(error);
						},
					});
					this.listarSucursales();
				}
			});
	}

	editarSucursal(dataSucursal: Sucursal) {
		this.dialog
			.open(DialogAddEditComponent, {
				disableClose: true,
				width: "600px",
				data: dataSucursal,
			})
			.afterClosed()
			.subscribe((resultado) => {
				if (resultado === "editado") {
					this.listarSucursales();
				}
			});
	}

	nuevaSucursal() {
		this.dialog
			.open(DialogAddEditComponent, {
				disableClose: true,
				width: "600px",
			})
			.afterClosed()
			.subscribe((resultado) => {
				if (resultado === "creado") {
					this.listarSucursales();
				}
			});
	}

	alerta(msg: string, accion: string) {
		this._snackBar.open(msg, accion, {
			horizontalPosition: "end",
			verticalPosition: "top",
			duration: 3000,
		});
	}
}
