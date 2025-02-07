import { Component, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Employee } from './../../../models/employee.model';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { EmployeeService } from '../../../services/employee.service';
import { loadEmployees } from '../../../store/actions/employee.actions';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';
import { TenantService } from '../../../services/tenant.service';
@Component({
  selector: 'app-employees-list',
  templateUrl: './employees.component.html',
  styleUrl: './employees.component.css',
  imports: [
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    MatChipsModule,
  ],
})
export class EmployeesComponent implements OnInit {
  errorMessage: string = '';
  tenantId: number = 0;
  displayedColumns: string[] = [
    'id',
    'name',
    'email',
    'role',
    'status',
    'actions',
  ];
  dataSource: MatTableDataSource<Employee> = new MatTableDataSource<Employee>(
    []
  );

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private employeeService: EmployeeService,
    private store: Store,
    private tenantService: TenantService
  ) {}

  ngOnInit() {
    this.tenantService.tenantId$.subscribe((tenantId) => {
      this.tenantId = Number(tenantId);
      if (isNaN(this.tenantId)) {
        this.tenantId = 0;
      }
      console.log('Tenant ID received:', this.tenantId);
    });
    this.fetchEmployees();
  }
  fetchEmployees() {
    this.employeeService.getEmployees(this.tenantId).subscribe(
      (employees) => {
        const employeesMap: Employee[] = employees.map((employee) => {
          const fullName =
            (employee.firstName || '') +
            (employee.middleName ? ' ' + employee.middleName : '') +
            (employee.lastName ? ' ' + employee.lastName : '');

          const active = employee.status === '1' ? 'Active' : 'InActive';

          // Return a new employee object with updated properties
          return {
            ...employee,
            fullName: fullName,
            active: active,
          };
        });
        console.log(employeesMap);
        this.store.dispatch(loadEmployees({ employees: employeesMap }));
        this.dataSource.data = employeesMap;

        // Ensure paginator and sort are set *after* data is available
        setTimeout(() => {
          if (this.paginator) {
            this.dataSource.paginator = this.paginator;
          }
          if (this.sort) {
            this.dataSource.sort = this.sort;
          }
        });
      },
      (error) => {
        this.errorMessage =
          error.status === 401
            ? 'Unable to find TenantId'
            : 'An error occurred. Please try again.';
        console.error('Error fetching employees:', error);
      }
    );
  }

  editEmployee(employee: Employee) {
    console.log('Edit:', employee);
    // Navigate to edit page or open a modal
  }

  deleteEmployee(id: number) {
    console.log('Delete Employee ID:', id);
    // Implement delete logic
  }
}
