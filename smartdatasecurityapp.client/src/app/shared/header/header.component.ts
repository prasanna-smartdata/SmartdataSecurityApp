import { Component, signal, Signal } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { NavbarComponent } from '../navbar/navbar.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import {
  selectIsLoggedIn,
  selectUser,
} from '../../store/selectors/auth.selectors';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  imports: [
    MatToolbarModule,
    NavbarComponent,
    CommonModule,
    MatButtonModule,
    RouterModule,
    MatMenuModule,
    MatIconModule,
  ],
})
export class HeaderComponent {
  title = signal<string>('Security Assignments');
  isChecked: any;
  isLoggedIn!: boolean;
  user!: any;

  constructor(
    private store: Store,
    private auth: AuthService,
    private router: Router
  ) {
    const token = localStorage.getItem('authToken'); // Get token from localStorage

    if (!token) {
      this.isLoggedIn = false;
    } else this.isLoggedIn = true;

    this.store.select(selectUser).subscribe((user) => {
      this.user = user;
    });
  }
  logout() {
    this.isLoggedIn = false;
    this.auth.removeToken();
    this.store.dispatch({ type: '[Auth] Logout' });
    this.router.navigateByUrl('/');
  }
}
