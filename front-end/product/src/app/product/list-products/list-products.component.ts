import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { ProductService } from '../product-service';
import { RouterModule } from '@angular/router';


interface Column {
  field: string;
  header: string;
}

@Component({
  selector: 'app-list-products',
  imports: [CommonModule, TableModule, ButtonModule, RouterModule],
  templateUrl: './list-products.component.html',
  styleUrl: './list-products.component.css'
})
export class ListProductsComponent implements OnInit {

  products = signal<Product[]>([]);
  cols!: Column[];

  constructor(private productService: ProductService) { }

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
}