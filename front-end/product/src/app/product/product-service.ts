import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../enviroments/environment.development';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClient: HttpClient) { }

  getAllProducts(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(environment.apiUrl + '/product');
  }

  getProductById(id: string): Observable<Product> {
    return this.httpClient.get<Product>(environment.apiUrl + 'product/' + id);
  }

  addProduct(product: Product): Observable<Product> {
    return this.httpClient.post<Product>(environment.apiUrl + 'product/', product);
  }
}
