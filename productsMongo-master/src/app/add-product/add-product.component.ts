import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { ProductsService } from '../Services/products.service';
import { Products } from '../Models/Products';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent {

  //injected Products service dependency
  constructor(private httpservice:ProductsService, private location:Location){}

  //created an object to store Products details
  Products: Products = {
    id: '',
    category:'',
    name: '',
    price:0
  };

  //go back functionality to have navigation capabilities
  goBack():void{
    this.location.back();
  }

  //calling add Products service
  addProducts(Products:Products){
    this.httpservice.addProducts(Products)
    .subscribe(
      {next:()=>
        {
          this.goBack()
        },error:
        (errorResponse)=>{
          console.log(errorResponse);
        }});}

}
