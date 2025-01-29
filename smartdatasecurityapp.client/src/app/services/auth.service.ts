import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee.model';
import { LoginRequest } from '../models/loginrequest.model';

interface LoginResponse {
  message: string;
  token: string;
}
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = '/api/token'; // Your API endpoint

  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<LoginResponse> {
    const request: LoginRequest = {
      userName: username,
      password: password,
    };
    // this.http.get('/api/token').subscribe((result) => {
    //   console.log(result);
    // });
    return this.http.post<LoginResponse>(`${this.apiUrl}`, request);
  }

  // Store the JWT token in localStorage
  saveToken(token: string): void {
    localStorage.setItem('authToken', token);
  }

  // Get the JWT token from localStorage
  getToken(): string | null {
    return localStorage.getItem('authToken');
  }

  // Remove the JWT token from localStorage
  removeToken(): void {
    localStorage.removeItem('authToken');
  }

  // Check if the user is logged in
  isLoggedIn(): boolean {
    return this.getToken() !== null;
  }
}
