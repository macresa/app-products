import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Category } from '../interfaces/category';
import { Product } from '../interfaces/product';

@Injectable({
  providedIn: 'root'
})
export class applicationService {
private appUrl: string = 'https://webapiproducts.azurewebsites.net/';
private apiP: string = 'api/products/';
private apiC: string = 'api/categories/';

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
   return this.http.get<Product[]>(`${this.appUrl}${this.apiP}`);
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.appUrl}${this.apiP}${id}`);
   }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.appUrl}${this.apiC}`);
   }

   addProduct(producto: Product): Observable<Product> {
     return this.http.post<Product>(`${this.appUrl}${this.apiP}`, producto);
   }

   updateProduct(producto: Product, id: number): Observable<void> {
    return this.http.put<void>(`${this.appUrl}${this.apiP}${id}`, producto);
  }
}
