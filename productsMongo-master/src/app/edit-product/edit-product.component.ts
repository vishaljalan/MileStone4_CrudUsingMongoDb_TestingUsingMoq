import { ActivatedRoute } from '@angular/router';
import { Products } from './../Models/Products';
import { Component } from '@angular/core';
import { ProductsService } from '../Services/products.service';
import { Location } from '@angular/common';


@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent {

  constructor(private ProductsService: ProductsService, private location: Location, private route: ActivatedRoute) {}

  //creating object of the model
  Products: Products = {
    id: '',
    category:'',
    name: '',
    price:0
  };
  //navigation functionality
  goBack(): void {
    this.location.back();
  }

  //calling edit Products
  editProducts(Products: Products): void {
    this.ProductsService.editProducts(Products)
    .subscribe(
      {next:() => 
        {this.goBack()
        },error:
        (errorResponse)=>{
          console.log(errorResponse);
        }});}

        //getting by id to call it in the edit Products which will fetch the Products by id
  getProductsById(): void {
    const id = String(this.route.snapshot.paramMap.get('id'));
    this.ProductsService.getProductsById(id)
    .subscribe(
      {next:Products => 
      {
      this.Products.id = Products.id,
      this.Products.category = Products.category,
      this.Products.name=Products.name,
      this.Products.price=Products.price
    },error:
    (errorResponse)=>{
      console.log(errorResponse);
    }});}


  ngOnInit(): void {
    this.getProductsById();
  }

}
