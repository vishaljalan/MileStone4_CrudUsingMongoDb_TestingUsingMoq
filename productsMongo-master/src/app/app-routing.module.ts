import { EditProductComponent } from './edit-product/edit-product.component';
import { AddProductComponent } from './add-product/add-product.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';

const routes: Routes = [
  { path:'products', component: ProductsComponent },
  { path: '', redirectTo:'products', pathMatch:'full' },
  { path:'products/addProducts', component: AddProductComponent },
  { path:'products/editProducts/:id', component: EditProductComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
