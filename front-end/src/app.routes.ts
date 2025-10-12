import { Routes } from '@angular/router';
import { ListProductsComponent } from '@/product/list-products/list-products.component';
import { CreateProductComponent } from '@/product/create-product/create-product.component';
import { UpdateProductComponent } from '@/product/update-product/update-product.component';
import { ProductResolve } from '@/Services/productResolve';

export const appRoutes: Routes = [
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
