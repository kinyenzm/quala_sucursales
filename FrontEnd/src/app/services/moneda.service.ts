import { Injectable } from "@angular/core";

import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Moneda } from "../interfaces/moneda";

@Injectable({
  providedIn: 'root'
})
export class MonedaService {
	private endpoint: string = "https://localhost:7029/api" + "/monedas";

	constructor(private http: HttpClient) {}

	getListaMonedas(): Observable<Moneda[]> {
		console.log(this.http.get<Moneda[]>(this.endpoint));
		return this.http.get<Moneda[]>(this.endpoint);
	}
}
