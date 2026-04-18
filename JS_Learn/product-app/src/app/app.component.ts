import { Component } from '@angular/core';
import { ProductComponent } from './product/product.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ProductComponent],
  template: `<app-product></app-product>` // ✅ inline template
})
export class AppComponent {}