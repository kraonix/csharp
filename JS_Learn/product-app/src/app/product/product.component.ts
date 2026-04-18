import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductFormComponent } from '../product-form/product-form.component';

interface Product {
  id: number;
  name: string;
  price: number;
  mfgDate: Date;
  expDate: Date;
}

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [CommonModule, ProductFormComponent],
  templateUrl: './product.component.html'
})
export class ProductComponent {

  products: Product[] = [
    {
      id: 110,
      name: 'Mobile',
      price: 142000,
      mfgDate: new Date('2014-02-12'),
      expDate: new Date('2019-02-12')
    },
    {
      id: 121,
      name: 'Camera',
      price: 50000,
      mfgDate: new Date('2015-03-11'),
      expDate: new Date('2018-03-11')
    },
    {
      id: 101,
      name: 'Earphone',
      price: 3000,
      mfgDate: new Date('2016-04-11'),
      expDate: new Date('2020-04-11')
    }
  ];

  public registerProduct(product: Product): void {
    this.products.push(product);
  }
}