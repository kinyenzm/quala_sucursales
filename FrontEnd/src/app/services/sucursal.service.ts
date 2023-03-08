import { Injectable } from "@angular/core";

import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Sucursal } from "../interfaces/sucursal";

@Injectable({
  providedIn: 'root'
})
export class SucursalService {
  private endpoint: string = "https://localhost:7029/api"+ "/sucursales";

  constructor(private http:HttpClient) { }

  getListaSucursales(): Observable<Sucursal[]> {
    return this.http.get<Sucursal[]>(this.endpoint);
  }

  getSucursal(codigo: number): Observable<Sucursal> {
    return this.http.get<Sucursal>(`${this.endpoint}/${codigo}`);
  }

  postSucursal(sucursal: Sucursal): Observable<Sucursal> {
    return this.http.post<Sucursal>(this.endpoint, sucursal);
  }

  putSucursal(sucursal: Sucursal): Observable<Sucursal> {
    return this.http.put<Sucursal>(`${this.endpoint}`, sucursal);
  }

  deleteSucursal(id: number | undefined): Observable<Sucursal> {
    console.log(id);
    return this.http.delete<Sucursal>(`${this.endpoint}/${id}`);
  }
}
