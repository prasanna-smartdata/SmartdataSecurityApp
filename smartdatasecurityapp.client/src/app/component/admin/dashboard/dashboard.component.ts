import { Component } from '@angular/core';
import { MatCard } from '@angular/material/card';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { CommonModule } from '@angular/common';
import { MatGridListModule } from '@angular/material/grid-list';
import { RouterModule } from '@angular/router';
import { EmployeesComponent } from '../employees/employees.component';
@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [MatGridListModule, CommonModule, RouterModule, EmployeesComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
})
export class DashboardComponent {
  currentBreakpoint = '';
  items: any;
  constructor(private breakpointObserver: BreakpointObserver) {
    this.breakpointObserver
      .observe([
        Breakpoints.XSmall,
        Breakpoints.Small,
        Breakpoints.Medium,
        Breakpoints.Large,
        Breakpoints.XLarge,
      ])
      .subscribe((result) => {
        if (result.breakpoints[Breakpoints.XSmall]) {
          this.currentBreakpoint = 'xs';
        } else if (result.breakpoints[Breakpoints.Small]) {
          this.currentBreakpoint = 'sm';
        } else if (result.breakpoints[Breakpoints.Medium]) {
          this.currentBreakpoint = 'md';
        } else if (result.breakpoints[Breakpoints.Large]) {
          this.currentBreakpoint = 'lg';
        } else if (result.breakpoints[Breakpoints.XLarge]) {
          this.currentBreakpoint = 'xl';
        }
      });
  }

  getColSpan() {
    switch (this.currentBreakpoint) {
      case 'xs':
        return 4; // Full-width
      case 'sm':
        return 2; // Half-width
      case 'md':
      case 'lg':
      case 'xl':
        return 1; // One-fourth width
      default:
        return 1;
    }
  }
}
