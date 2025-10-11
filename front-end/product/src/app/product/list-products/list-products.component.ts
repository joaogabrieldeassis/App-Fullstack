import { Component, Inject, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Table, TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { ProductService } from '../product-service';
import { RouterModule } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { InputIconModule } from 'primeng/inputicon';
import { IconFieldModule } from 'primeng/iconfield';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { RatingModule } from 'primeng/rating';
import { Product } from '../models/product';


interface Column {
  field: string;
  header: string;
}

@Component({
  selector: 'app-list-products',
  imports: [CommonModule,
    TableModule,
    ButtonModule,
    RouterModule,
    InputIconModule,
    IconFieldModule,
    ConfirmDialogModule,
    RatingModule,],
  templateUrl: './list-products.component.html',
  styleUrl: './list-products.component.css',
  providers: [ConfirmationService, MessageService]
})
export class ListProductsComponent implements OnInit {

  products = signal<Product[]>([]);
  cols!: Column[];
  selectedProducts!: Product[] | null;

  constructor(private productService: ProductService,
    @Inject(ConfirmationService) private confirmationService: ConfirmationService,
    private messageService: MessageService,) { }

  ngOnInit() {
    this.loadProducts();
    this.cols = [
      { field: 'code', header: 'Code' },
      { field: 'name', header: 'Name' },
      { field: 'category', header: 'Category' },
      { field: 'price', header: 'Price' }
    ];
  }

  loadProducts() {
    this.productService.getAllProducts()
      .subscribe(products => {
        this.products.set(products)
      });
  }

  onGlobalFilter(table: Table, event: Event) {
    table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
  }

  deleteProduct(product: Product) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + product.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.products.set(this.products().filter((val) => val.id !== product.id));
        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'Product Deleted',
          life: 3000
        });
      }
    });
  }
}