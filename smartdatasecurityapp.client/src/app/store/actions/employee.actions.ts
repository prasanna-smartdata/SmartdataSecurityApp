import { createAction, props } from '@ngrx/store';
import { Employee } from '../../models/employee.model';

// Load Employees
export const loadEmployees = createAction(
  '[Employee] Load Employees',
  props<{ employees: Employee[] }>()
);

// Load Employees Failure
export const loadEmployeesFailure = createAction(
  '[Employee] Load Employees Failure',
  props<{ error: string }>()
);

// Add Employee
export const addEmployee = createAction(
  '[Employee] Add Employee',
  props<{ employee: Employee }>()
);

// Update Employee
export const updateEmployee = createAction(
  '[Employee] Update Employee',
  props<{ employee: Employee }>()
);

// Delete Employee
export const deleteEmployee = createAction(
  '[Employee] Delete Employee',
  props<{ employeeId: number }>()
);
