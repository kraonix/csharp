import { Component, signal, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Child } from '../child/child';

@Component({
  selector: 'app-parent',
  imports: [FormsModule, Child],
  templateUrl: './parent.html',
  styleUrl: './parent.css',
})
export class Parent {
  // Signal to hold the list of countries
  countries = signal<string[]>([
    'India',
    'USA',
    'Canada',
    'Australia',
    'Germany'
  ]);

  // Signal for selected country
  selectedCountry = signal<string>('');

  // Output to send selected country to child
  countrySelected = output<string>();

  // Handle country selection change
  onCountryChange(event: Event): void {
    const select = event.target as HTMLSelectElement;
    this.selectedCountry.set(select.value);
    this.countrySelected.emit(select.value);
  }
}
