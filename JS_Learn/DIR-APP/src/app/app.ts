import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule], // ✅ THIS is required
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('DIR-APP');
  showMessage = false;

  emps: any[] = [
    { id: 1, name: 'John Doe', position: 'Software Engineer' },
    { id: 2, name: 'Jane Smith', position: 'Product Manager' },
    { id: 3, name: 'Alice Johnson', position: 'UX Designer' }
  ];
}