import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  Validators,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatButton } from '@angular/material/button';
import { AuthService } from '../../services/auth.service';
import { Store } from '@ngrx/store';
import { login } from '../../store/actions/auth.actions';
import { Employee } from '../../models/employee.model';
import { EmployeeService } from '../../services/employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  imports: [
    MatIconModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatFormFieldModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatButton,
  ],
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  loginForm: FormGroup;
  hidePassword = true;
  username: string = '';
  password: string = '';
  message: string = '';
  errorMessage: string = '';
  employee: Employee | undefined;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private employeeService: EmployeeService,
    private store: Store,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      const { username, password } = this.loginForm.value;
      this.authService.login(username, password).subscribe(
        (response) => {
          console.log('Login Successful:', response);

          // Handle successful login (e.g., store the JWT token or redirect)
          this.authService.saveToken(response.token);
          this.message = response.message;
          this.errorMessage = '';

          const user = response.user;
          this.store.dispatch(login({ user: user }));

          this.employeeService.getEmployeeById(user.employeeId).subscribe(
            (data) => {
              this.employee = data;
              console.log(this.employee.status === 1);

              if (this.employee.status === 1) {
                switch (String(this.employee.roleId)) {
                  case '1':
                    this.router.navigateByUrl('/superadmin/dashboard');
                    break;

                  case '2':
                    this.router.navigateByUrl('/admin/dashboard');
                    break;
                  default:
                    break;
                }
              } else {
                this.errorMessage = 'User is Inactive';
              }
            },
            (error) => {
              console.error('Error fetching employee:', error);
            }
          );
        },
        (error) => {
          // Handle failed login (e.g., show an error message)
          if (error.status === 401) {
            this.errorMessage = 'Invalid username or password';
          } else {
            this.errorMessage = 'An error occurred. Please try again.';
          }
          this.message = '';
          console.log('Login Failed:', error);
        }
      );
    }
  }

  onForgotPassword(): void {
    console.log('Forgot Password Clicked');
    // Implement forgot password logic here
  }
}
