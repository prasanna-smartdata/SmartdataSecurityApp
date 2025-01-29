import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './component/dashboard/dashboard.component';
import { DefaultComponent } from './layout/default/default.component';
import { AdminComponent } from './component/admin/admin.component';
import { SettingsComponent } from './component/admin/settings/settings.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { LoginComponent } from './component/login/login.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  {
    path: '',
    component: DefaultComponent,
    children: [
      { path: '', redirectTo: 'login', pathMatch: 'full' }, // Redirect to login by default
      { path: 'login', component: LoginComponent },
      {
        path: 'dashboard',
        component: DashboardComponent,
        canActivate: [AuthGuard], // Protect this route
      },
      {
        path: 'admin',
        component: AdminComponent,
        canActivate: [AuthGuard], // Protect the admin section
        children: [
          {
            path: 'settings',
            component: SettingsComponent,
            canActivate: [AuthGuard], // Protect nested route
          },
        ],
      },
    ],
  },
  { path: '**', component: NotfoundComponent }, // Wildcard for 404
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
