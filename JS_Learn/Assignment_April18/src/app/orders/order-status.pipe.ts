import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'orderStatus',
  standalone: true
})
export class OrderStatusPipe implements PipeTransform {
  transform(value: number): string {
    switch (value) {
      case 0:
        return 'Pending';
      case 1:
        return 'Shipped';
      case 2:
        return 'Delivered';
      default:
        return 'Unknown';
    }
  }
}