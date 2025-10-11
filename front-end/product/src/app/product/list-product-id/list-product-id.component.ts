import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductService } from '../product-service';

@Component({
  selector: 'app-list-product-id',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './list-product-id.component.html',
  styleUrl: './list-product-id.component.css'
})
export class ListProductIdComponent {
  productId = '';
  product = signal<Product | null>(null);

  constructor(private productService: ProductService) { }

  findById() {
    this.productService.getProductById(this.productId)
      .subscribe((p) => this.product.set(p));
  }
}