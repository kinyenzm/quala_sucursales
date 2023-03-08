import { Component, OnInit, Inject } from "@angular/core";

import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { Sucursal } from "src/app/interfaces/sucursal";

@Component({
  selector: 'app-dialog-delete',
  templateUrl: './dialog-delete.component.html'
})
export class DialogDeleteComponent {
	constructor(
		private dialog: MatDialogRef<DialogDeleteComponent>,
		@Inject(MAT_DIALOG_DATA) public sucursal: Sucursal,
	) {}

	ngOnInit(): void {}

	confirmar_Eliminar() {
		console.log("Eliminar: ", this.sucursal);
		this.dialog.close("eliminado");
	}
}
