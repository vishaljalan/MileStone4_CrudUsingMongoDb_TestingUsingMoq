import { Products } from './../Models/Products';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private http:HttpClient) { }

  

  //giving base url at which the service http will be called
  baseUrl: string = "https://localhost:7095/api/";

  //craeting services for crud operations

  getAllProducts(): Observable<Products[]>{
    return this.http.get<Products[]>(this.baseUrl + `Products`);
  }

  getProductsById(id:string):Observable<any>{
    return this.http.get<any>(this.baseUrl +`Products/${id}`);
  }

  deleteProducts(id:string):Observable<any>{
    return this.http.delete<any>(this.baseUrl + `Products/${id}`);
  }

  addProducts(Products:Products):Observable<any>{
    return this.http.post<any>(this.baseUrl + `Products`,Products);
  }

  editProducts(Products:Products):Observable<any>{
    return this.http.put<any>(this.baseUrl + `Products/${Products.id}`,Products);
  } 
}
