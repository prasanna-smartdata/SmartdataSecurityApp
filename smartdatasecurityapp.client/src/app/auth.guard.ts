import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { selectIsLoggedIn } from './store/selectors/auth.selectors';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { AuthService } from './services/auth.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(
    private router: Router,
    private authService: AuthService,
    private store: Store
  ) {}

  canActivate(): boolean {
    const token = localStorage.getItem('authToken'); // Get token from localStorage

    if (!token) {
      this.router.navigate(['/login']);
      return false;
    }

    return true;
  }
}
