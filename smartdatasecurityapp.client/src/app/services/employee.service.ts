import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee.model';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private apiUrl = 'api/employee';

  constructor(private http: HttpClient) {}

  getEmployeeById(employeeId: number): Observable<Employee> {
    const url = `${this.apiUrl}/${employeeId}`;

    // Add any necessary headers, such as Authorization headers with the JWT token
    const headers = new HttpHeaders().set(
      'Authorization',
      `Bearer ${localStorage.getItem('authToken')}`
    );

    console.log(headers);
    return this.http.get<Employee>(url, { headers });
  }
}
