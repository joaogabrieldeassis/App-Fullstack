import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot } from '@angular/router';
import { ProductService } from '../product/product-service';


@Injectable({
    providedIn: 'root'
})

export class ProductResolve {

    constructor(private productService: ProductService) { }

    resolve(route: ActivatedRouteSnapshot) {
        return this.productService.getProductById(route.params['id']);
    }

}