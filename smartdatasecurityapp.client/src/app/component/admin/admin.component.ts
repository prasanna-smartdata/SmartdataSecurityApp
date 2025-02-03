import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-admin',
  imports: [SharedModule],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.scss',
})
export class AdminComponent {
  constructor() {}
  ngOnInit(): void {}
}
