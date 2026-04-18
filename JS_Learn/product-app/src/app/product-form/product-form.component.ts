import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

export interface ProductFormModel {
  id: number;
  name: string;
  price: number;
  mfgDate: string;
  expDate: string;
}

@Component({
  selector: 'app-product-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product-form.component.html'
})
export class ProductFormComponent {
  @Output() productRegistered = new EventEmitter<{
    id: number;
    name: string;
    price: number;
    mfgDate: Date;
    expDate: Date;
  }>();

  product: ProductFormModel = {
    id: 0,
    name: '',
    price: 0,
    mfgDate: '',
    expDate: ''
  };

  submitted = false;

  registerProduct(): void {
    if (
      !this.product.id ||
      !this.product.name.trim() ||
      !this.product.price ||
      !this.product.mfgDate ||
      !this.product.expDate
    ) {
      return;
    }

    this.productRegistered.emit({
      id: this.product.id,
      name: this.product.name.trim(),
      price: this.product.price,
      mfgDate: new Date(this.product.mfgDate),
      expDate: new Date(this.product.expDate)
    });

    this.submitted = true;
    this.product = {
      id: 0,
      name: '',
      price: 0,
      mfgDate: '',
      expDate: ''
    };
  }
}
