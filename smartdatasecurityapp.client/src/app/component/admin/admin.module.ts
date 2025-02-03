import { NgModule } from '@angular/core';
import { SettingsComponent } from './settings/settings.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AssignmentsComponent } from './assignments/assignments.component';

@NgModule({
  declarations: [AssignmentsComponent],
  imports: [SettingsComponent],
  exports: [],
})
export class AdminModule {}
