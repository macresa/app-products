import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Product } from 'src/app/interfaces/product';
import { applicationService } from 'src/app/services/application.service';

@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styleUrls: ['./list-products.component.css']
})


export class ListProductsComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['nombre', 'marca','categorianombre', 'descripcion', 'precio'];
  dataSource = new MatTableDataSource<Product>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;


  constructor(private _service:applicationService) { }

  ngOnInit(): void {
    this.getProducts();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
  getProducts(){
 this._service.getProducts().subscribe(data =>{
  this.dataSource.data = data;
 })
  }

}
