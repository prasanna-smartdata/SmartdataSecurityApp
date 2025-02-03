import { createReducer, on } from '@ngrx/store';
import { Employee } from '../../models/employee.model';
import * as EmployeeActions from '../actions/employee.actions';

// Initial State
export interface EmployeeState {
  employees: Employee[];
  loading: boolean;
  error: string | null;
}

export const initialState: EmployeeState = {
  employees: [],
  loading: false,
  error: null,
};

export const employeeReducer = createReducer(
  initialState,

  on(EmployeeActions.loadEmployees, (state, { employees }) => ({
    ...state,
    loading: false,
    employees,
  })),
  on(EmployeeActions.loadEmployeesFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error,
  })),

  // Add Employee
  on(EmployeeActions.addEmployee, (state, { employee }) => ({
    ...state,
    employees: [...state.employees, employee],
  })),

  // Update Employee
  on(EmployeeActions.updateEmployee, (state, { employee }) => ({
    ...state,
    employees: state.employees.map((emp) =>
      emp.id === employee.id ? { ...emp, ...employee } : emp
    ),
  })),

  // Delete Employee
  on(EmployeeActions.deleteEmployee, (state, { employeeId }) => ({
    ...state,
    employees: state.employees.filter((emp) => emp.id !== employeeId),
  }))
);
