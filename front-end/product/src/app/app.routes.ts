import { Routes } from '@angular/router';
import { CreateProductComponent } from './product/create-product/create-product.component';
import { ListProductsComponent } from './product/list-products/list-products.component';
import { UpdateProductComponent } from './product/update-product/update-product.component';
import { ProductResolve } from './product/product-service.resolve';

export const routes: Routes = [
    {
        path: '', component: ListProductsComponent
    },
    { path: 'product/create', component: CreateProductComponent },
    {
        path: 'product/update/:id',
        component: UpdateProductComponent,
        resolve: {
            product: ProductResolve
        },
    },
];
