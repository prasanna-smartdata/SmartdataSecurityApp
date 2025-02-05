import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TenantService {
  private tenantIdSubject = new BehaviorSubject<string | null>(
    this.getTenantIdFromStorage()
  );
  tenantId$ = this.tenantIdSubject.asObservable();

  // Set the tenantId
  setTenantId(tenantId: string): void {
    localStorage.setItem('tenantId', tenantId); // Store the tenantId in localStorage
    this.tenantIdSubject.next(tenantId); // Update the BehaviorSubject
  }
  getTenantIdFromStorage(): string | null {
    return localStorage.getItem('tenantId');
  }
  // Get the tenantId
  getTenantId(): string | null {
    return this.tenantIdSubject.value;
  }
}
