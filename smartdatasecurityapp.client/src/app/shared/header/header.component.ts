import { Component, signal, Signal } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { NavbarComponent } from '../navbar/navbar.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import {
  selectIsLoggedIn,
  selectUser,
} from '../../store/selectors/auth.selectors';

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

  constructor(private store: Store) {
    this.store.select(selectIsLoggedIn).subscribe((loggedIn) => {
      this.isLoggedIn = loggedIn;
      console.log('Logged In Status:', loggedIn);
    });

    this.store.select(selectUser).subscribe((user) => {
      this.user = user;
      console.log('User:', user);
    });
  }
  logout() {
    this.store.dispatch({ type: '[Auth] Logout' });
  }
}
