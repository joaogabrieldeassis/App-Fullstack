import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../enviroments/environment.development';
import { Product } from './models/product';


@Injectable({
    providedIn: 'root'
})
export class ProductService {

    constructor(private httpClient: HttpClient) { }

    getAllProducts(): Observable<Product[]> {
        return this.httpClient.get<Product[]>(environment.apiUrl + 'Product');
    }

    getProductById(id: string): Observable<Product> {
        return this.httpClient.get<Product>(environment.apiUrl + 'Product/' + id);
    }

    addProduct(product: Product): Observable<Product> {
        return this.httpClient.post<Product>(environment.apiUrl + 'Product/', product);
    }

    deleteProduct(id: string): Observable<boolean> {
        return this.httpClient.delete<boolean>(environment.apiUrl + 'Product/' + id);
    }
}
