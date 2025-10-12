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
import { ToolbarModule } from 'primeng/toolbar';

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
    RatingModule,
    ToolbarModule],
  templateUrl: './list-products.component.html',
  styleUrl: './list-products.component.scss',
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
      message: 'Tem certeza de que deseja excluir ' + product.name + '?',
      header: 'Confirmação',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.productService.deleteProduct(product.id)
          .subscribe(
            success => {
              this.products.update(list => list.filter(p => p.id !== product.id));
              this.messageService.add({
                severity: 'success',
                summary: 'Sucesso',
                detail: 'Produto excluído',
                life: 3000
              });
            },
            falha => {
              this.messageService.add({
                severity: 'error',
                summary: 'Erro',
                detail: 'Houve uma falha interna ao deletar o produto.'
              });
            }
          )
      }
    });
  }

}