import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar'; // Import Material Toolbar
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  imports: [
    CommonModule,
    MatToolbarModule,
    HeaderComponent,
    FooterComponent,
    RouterModule,
  ],
  exports: [HeaderComponent, RouterModule, FooterComponent],
})
export class SharedModule {}
