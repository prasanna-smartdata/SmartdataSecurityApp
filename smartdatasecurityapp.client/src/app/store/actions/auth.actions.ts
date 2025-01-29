import { createAction, props } from '@ngrx/store';
import { Employee } from '../../models/employee.model';

export const login = createAction('[Auth] Login', props<{ user: Employee }>());
export const logout = createAction('[Auth] Logout');
export const updateUser = createAction(
  '[Auth] Update User',
  props<{ user: Employee }>()
);
