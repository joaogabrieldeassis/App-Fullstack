import { Routes } from '@angular/router';
import { CreateProductComponent } from './product/create-product/create-product.component';
import { DeletedProductComponent } from './product/deleted-product/deleted-product.component';
import { ListProductIdComponent } from './product/list-product-id/list-product-id.component';
import { ListProductsComponent } from './product/list-products/list-products.component';
import { UpdateProductComponent } from './product/update-product/update-product.component';

export const routes: Routes = [
    { path: 'products', component: ListProductsComponent },
    { path: 'products/create', component: CreateProductComponent },
    { path: 'products/delete/:id', component: DeletedProductComponent },
    { path: 'products/:id', component: ListProductIdComponent },
    { path: 'products/update/:id', component: UpdateProductComponent },
];
