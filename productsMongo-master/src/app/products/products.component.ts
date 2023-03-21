import { Component } from '@angular/core';
import { ProductsService } from '../Services/products.service';
import { Products } from '../Models/Products';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent {

  //injecting service dependency
  constructor(private httpservice:ProductsService){}

  //creating objects 
  Products:Products[]=[];
  id?:string;

  //calling get Products functionality
  getAllProducts(){
    this.httpservice.getAllProducts()
    .subscribe({next:
      (Products) => {
        this.Products=Products;
        console.log(Products);
        },error:
      (errorResponse)=> {
        console.log(errorResponse);
      }});}

  //calling delete Products functionality
  deleteProducts(id:string){
    this.httpservice.deleteProducts(id)
    .subscribe({next:
      ()=>{
        this.getAllProducts;
      },error:
      (errorResponse)=>{
        console.log(errorResponse);
      }});}

  ngOnInit(): void {
    this.getAllProducts();

    }
}
