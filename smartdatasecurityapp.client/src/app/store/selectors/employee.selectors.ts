import { createSelector, createFeatureSelector } from '@ngrx/store';
import { EmployeeState } from '../reducers/employee.reducer';

// Feature Selector
export const selectEmployeeState =
  createFeatureSelector<EmployeeState>('employees');

// Select All Employees
export const selectAllEmployees = createSelector(
  selectEmployeeState,
  (state) => state.employees
);

// Select Loading State
export const selectEmployeeLoading = createSelector(
  selectEmployeeState,
  (state) => state.loading
);

// Select Error
export const selectEmployeeError = createSelector(
  selectEmployeeState,
  (state) => state.error
);
