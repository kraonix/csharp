import { Component, input, signal, effect } from '@angular/core';

@Component({
  selector: 'app-child',
  standalone: true,
  templateUrl: './child.html',
  styleUrl: './child.css',
})
export class Child {
  // Input to receive country from parent
  country = input<string>('');

  // Signal to hold states based on selected country
  states = signal<string[]>([]);

  // Map of countries to their states
  private countryStates: { [key: string]: string[] } = {
    'India': ['Maharashtra', 'Delhi', 'Karnataka', 'Tamil Nadu', 'Gujarat', 'West Bengal'],
    'USA': ['California', 'Texas', 'Florida', 'New York', 'Illinois', 'Pennsylvania'],
    'Canada': ['Ontario', 'Quebec', 'British Columbia', 'Alberta', 'Manitoba'],
    'Australia': ['New South Wales', 'Victoria', 'Queensland', 'Western Australia', 'South Australia'],
    'Germany': ['Bavaria', 'North Rhine-Westphalia', 'Baden-Württemberg', 'Hesse', 'Saxony']
  };

  constructor() {
    // Use effect to react to country input changes
    effect(() => {
      const selectedCountry = this.country();
      if (selectedCountry && this.countryStates[selectedCountry]) {
        this.states.set(this.countryStates[selectedCountry]);
      } else {
        this.states.set([]);
      }
    });
  }
}
