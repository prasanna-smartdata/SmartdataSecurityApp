import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './component/dashboard/dashboard.component';
import { DashboardComponent as AdminDashboardComponent } from './component/admin/dashboard/dashboard.component';
import { DashboardComponent as SuperAdminDashboardComponent } from './component/superadmin/dashboard/dashboard.component';
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
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      {
        path: 'dashboard',
        component: DashboardComponent,
        canActivate: [AuthGuard],
      },
      {
        path: 'admin',
        component: AdminComponent,
        canActivate: [AuthGuard],
        children: [
          {
            path: 'dashboard',
            component: AdminDashboardComponent,
            canActivate: [AuthGuard],
          },
          {
            path: 'settings',
            component: SettingsComponent,
            canActivate: [AuthGuard],
          },
        ],
      },
      {
        path: 'superadmin',
        canActivate: [AuthGuard],
        children: [
          {
            path: 'dashboard',
            component: SuperAdminDashboardComponent,
            canActivate: [AuthGuard],
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
