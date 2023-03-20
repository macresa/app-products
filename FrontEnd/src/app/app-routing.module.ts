import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './components/add-product/add-product.component';
import { ListProductsComponent } from './components/list-products/list-products.component';
import { UpdateProductComponent } from './components/update-product/update-product.component';

const routes: Routes = [
 {path: '', component: ListProductsComponent},
 {path: 'add', component: AddProductComponent},
 {path: 'add/:id', component: UpdateProductComponent},
 {path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
