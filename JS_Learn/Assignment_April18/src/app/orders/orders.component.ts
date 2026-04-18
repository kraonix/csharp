import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderStatusPipe } from './order-status.pipe';

interface Order {
  id: number;
  productName: string;
  price: number;
  orderDate: Date;
  status: number;
}

@Component({
  selector: 'app-orders',
  standalone: true,
  imports: [CommonModule, OrderStatusPipe],
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.css'
})
export class OrdersComponent {
  orders: Order[] = [
    { id: 1, productName: 'Laptop', price: 999.99, orderDate: new Date('2026-04-15'), status: 2 },
    { id: 2, productName: 'Smartphone', price: 699.50, orderDate: new Date('2026-04-16'), status: 1 },
    { id: 3, productName: 'Headphones', price: 149.99, orderDate: new Date('2026-04-17'), status: 0 },
    { id: 4, productName: 'Keyboard', price: 79.99, orderDate: new Date('2026-04-18'), status: 0 },
    { id: 5, productName: 'Monitor', price: 349.00, orderDate: new Date('2026-04-14'), status: 2 },
    { id: 6, productName: 'Mouse', price: 49.99, orderDate: new Date('2026-04-17'), status: 1 },
  ];
}