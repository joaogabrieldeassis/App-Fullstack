import { CommonModule } from '@angular/common';
import { Component, ViewChild } from '@angular/core';
import { FormsModule, NgForm, ReactiveFormsModule, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { ToastModule } from 'primeng/toast';
import { ToolbarModule } from 'primeng/toolbar';
import { RatingModule } from 'primeng/rating';
import { InputTextModule } from 'primeng/inputtext';
import { TextareaModule } from 'primeng/textarea';
import { SelectModule } from 'primeng/select';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputNumberModule } from 'primeng/inputnumber';
import { DialogModule } from 'primeng/dialog';
import { TagModule } from 'primeng/tag';
import { InputIconModule } from 'primeng/inputicon';
import { IconFieldModule } from 'primeng/iconfield';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ProductService } from '../product-service';
import { ToastrService } from 'ngx-toastr';
import { Product } from '../models/product';
import { Router, RouterModule } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { FloatLabelModule } from 'primeng/floatlabel';

@Component({
  selector: 'app-create-product',
  imports: [CommonModule,
    FormsModule,
    ButtonModule,
    RippleModule,
    ToastModule,
    ToolbarModule,
    RatingModule,
    InputTextModule,
    TextareaModule,
    SelectModule,
    RadioButtonModule,
    InputNumberModule,
    DialogModule,
    TagModule,
    InputIconModule,
    IconFieldModule,
    ConfirmDialogModule,
    RouterModule,
    ReactiveFormsModule,
    FloatLabelModule],
  templateUrl: './create-product.component.html',
  styleUrl: './create-product.component.scss',
  providers: [ConfirmationService, MessageService]
})
export class CreateProductComponent {
  form!: UntypedFormGroup;
  product!: Product;
  @ViewChild('supportNgForm') supportNgForm!: NgForm;

  constructor(private productService: ProductService,
    private _formBuilder: UntypedFormBuilder,
    private toastr: ToastrService,
    private messageService: MessageService,
    private router: Router) {

    this.form = this._formBuilder.group({
      name: ['', Validators.required],
      price: [null, [Validators.required]],
      description: ['', [Validators.required]],
      quantity: [null, Validators.required]
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
    this.supportNgForm.reset();
    this.messageService.add({
      severity: 'success',
      summary: 'Sucesso',
      detail: 'Produto cadastrado com sucesso!'
    });

    setTimeout(() => {
      this.router.navigate(['/']);
    }, 2000);
  }

  processarFalha(fail: any) {
    let todasMensagens = '';
    fail.error.errors.forEach((errorMessage: string) => {
      todasMensagens += errorMessage + '\n';
      this.toastr.error(errorMessage, '');
    });

    todasMensagens = todasMensagens.trim();
    this.messageService.add({
      severity: 'error',
      summary: 'Erro',
      detail: todasMensagens
    });
  }
}