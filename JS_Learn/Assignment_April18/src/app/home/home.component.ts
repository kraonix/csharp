import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="home-container">
      <h1>Welcome to Order Tracking System</h1>
      <p>Track your orders easily and efficiently.</p>
      <div class="features">
        <div class="feature-card">
          <h3>📦 Track Orders</h3>
          <p>View all your orders in one place</p>
        </div>
        <div class="feature-card">
          <h3>🚚 Order Status</h3>
          <p>Know exactly where your order is</p>
        </div>
        <div class="feature-card">
          <h3>📅 Order History</h3>
          <p>View your complete order history</p>
        </div>
      </div>
    </div>
  `,
  styles: [`
    .home-container {
      padding: 2rem;
      text-align: center;
    }
    h1 {
      color: #333;
      margin-bottom: 1rem;
    }
    p {
      color: #666;
      font-size: 1.2rem;
      margin-bottom: 2rem;
    }
    .features {
      display: flex;
      justify-content: center;
      gap: 2rem;
      flex-wrap: wrap;
    }
    .feature-card {
      background: #f8f9fa;
      padding: 2rem;
      border-radius: 8px;
      box-shadow: 0 2px 4px rgba(0,0,0,0.1);
      width: 200px;
    }
    .feature-card h3 {
      color: #333;
      margin-bottom: 0.5rem;
    }
    .feature-card p {
      color: #666;
      font-size: 0.9rem;
    }
  `]
})
export class HomeComponent {}