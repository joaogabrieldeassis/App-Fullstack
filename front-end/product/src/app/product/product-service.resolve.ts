import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot } from '@angular/router';
import { ProductService } from './product-service';


@Injectable()
export class ProductResolve {

    constructor(private productService: ProductService) { }

    resolve(route: ActivatedRouteSnapshot) {        
        return this.productService.getProductById(route.params['id']);                
    }

}