import { Component } from '@angular/core';
import { 
  UpperCasePipe, 
  LowerCasePipe, 
  TitleCasePipe, 
  CurrencyPipe 
} from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    UpperCasePipe,
    LowerCasePipe,
    TitleCasePipe,
    CurrencyPipe
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App {

  products: any[] = [];

  ngOnInit() {
    this.products = [
      { id: 1, name: 'iPhone 15', price: 80000, category: 'Electronics' },
      { id: 2, name: 'Samsung TV', price: 50000, category: 'Electronics' },
      { id: 3, name: 'Laptop', price: 70000, category: 'Electronics' },
      { id: 4, name: 'Headphones', price: 3000, category: 'Electronics' },
      { id: 5, name: 'Smart Watch', price: 5000, category: 'Electronics' },

      { id: 6, name: 'T-Shirt', price: 800, category: 'Clothing' },
      { id: 7, name: 'Jeans', price: 2000, category: 'Clothing' },
      { id: 8, name: 'Jacket', price: 3500, category: 'Clothing' },
      { id: 9, name: 'Sneakers', price: 4000, category: 'Clothing' },
      { id: 10, name: 'Hoodie', price: 1500, category: 'Clothing' },

      { id: 11, name: 'Wall Art', price: 1200, category: 'Home Decor' },
      { id: 12, name: 'Lamp', price: 1800, category: 'Home Decor' },
      { id: 13, name: 'Sofa Cover', price: 2500, category: 'Home Decor' },
      { id: 14, name: 'Curtains', price: 2200, category: 'Home Decor' },
      { id: 15, name: 'Vase', price: 900, category: 'Home Decor' },

      { id: 16, name: 'Mixer', price: 3000, category: 'Appliances' },
      { id: 17, name: 'Microwave', price: 9000, category: 'Appliances' },
      { id: 18, name: 'Fan', price: 2000, category: 'Appliances' },
      { id: 19, name: 'Iron', price: 1200, category: 'Appliances' },
      { id: 20, name: 'Air Cooler', price: 7000, category: 'Appliances' }
    ];
  }
}