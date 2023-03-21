import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Product } from 'src/app/interfaces/product';
import { applicationService } from 'src/app/services/application.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-update-product',
  templateUrl: './update-product.component.html',
  styleUrls: ['./update-product.component.css']
})
export class UpdateProductComponent implements OnInit {
 form: FormGroup;
  listcategory: Array<any> = []
  id_: number;
  selectedcat: String = '';

  constructor(private fb: FormBuilder, private _service:applicationService, private _snackBar: MatSnackBar,
    private activatedRoute: ActivatedRoute) { 
    
    this.id_ = Number(this.activatedRoute.snapshot.paramMap.get('id'));

    this.form = this.fb.group({
      nombre: [''] ,
      marca: [''],
      descripcion: [''],
      precio: [''],
      categoria: ['']
    })   
  }

  ngOnInit(): void {
    this.getCategories();
    this.getProduct(this.id_);
  }

  openSnackBar() {

    this._snackBar.open('The product was updated successfully!', 'Close', {
      horizontalPosition: 'right',
      duration: 3000
    });
  }

  getProduct(id: number){
    this._service.getProduct(id).subscribe(data =>{

        this.form.patchValue(
        {
        nombre: data.name,
        marca: data.brand,
        descripcion: data.description,
        categoria: data.categoryId,
        categorianombre: data.categoryName,
        precio: data.price
        });   
        this.selectedcat = data.categoryName!;
    })

     }

  updateProduct () {
    if(this.form.valid){
      const producto: Product = {
        name: this.form.value.nombre,
        brand: this.form.value.marca,
        description: this.form.value.descripcion,
        categoryId: this.form.value.categoria,
        price: this.form.value.precio 
      }
    this._service.updateProduct(producto, this.id_).subscribe(data => console.log(data));
    this.openSnackBar();
    }
  }

  getCategories(){
    this._service.getCategories().subscribe((data:any) =>{
      this.listcategory = data;
      console.log(data);
    })
  }

}
