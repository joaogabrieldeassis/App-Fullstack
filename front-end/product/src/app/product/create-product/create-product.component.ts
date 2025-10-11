import { Component, signal, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm, ReactiveFormsModule, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { ProductService } from '../product-service';
import { RouterModule } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Product } from '../models/product'

@Component({
  standalone: true,
  selector: 'app-create-product',
  imports: [CommonModule, FormsModule, RouterModule, ReactiveFormsModule],
  templateUrl: './create-product.component.html',
  styleUrl: './create-product.component.css'
})
export class CreateProductComponent {
  form!: UntypedFormGroup;
  product!: Product;
  errors: any[] = [];

  @ViewChild('supportNgForm') supportNgForm!: NgForm;
  constructor(private productService: ProductService,
    private _formBuilder: UntypedFormBuilder,
    private toastr: ToastrService) {

    this.form = this._formBuilder.group({
      name: ['', Validators.required],
      price: ['', [Validators.required]],
      description: ['', [Validators.required]],
    });
  }


  saveProduct() {
    if (this.form.dirty && this.form.valid) {
      this.product = Object.assign(this.product || {}, this.form.value);

      this.productService.addProduct(this.product)
        .subscribe(
          success => { this.processarSucesso(success) },
          falha => { this.processarFalha(falha) }
        )

    }
  }

  processarSucesso(response: any) {
    this.supportNgForm.resetForm();
    this.errors = [];
    this.toastr.success('Produto cadastrado com sucesso!', 'Sucesso!');
  }

  processarFalha(fail: any) {
    this.toastr.error('Ocorreu um erro!', 'Opa :(');

    fail.error.errors.forEach((errorMesage: string) => {
      this.toastr.error(`${errorMesage}`, '');
    });
  }
}
