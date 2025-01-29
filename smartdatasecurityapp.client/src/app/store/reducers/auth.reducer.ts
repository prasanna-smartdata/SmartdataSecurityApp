import { createReducer, on } from '@ngrx/store';
import { login, logout, updateUser } from '../actions/auth.actions';
import { Employee } from '../../models/employee.model';

export interface AuthState {
  user: Employee | null;
  isLoggedIn: boolean;
}

export const initialState: AuthState = {
  user: null,
  isLoggedIn: false,
};

export const authReducer = createReducer(
  initialState,
  on(login, (state, { user }) => ({ ...state, user, isLoggedIn: true })),
  on(logout, (state) => ({ ...state, user: null, isLoggedIn: false })),
  on(updateUser, (state, { user }) => ({ ...state, user }))
);
