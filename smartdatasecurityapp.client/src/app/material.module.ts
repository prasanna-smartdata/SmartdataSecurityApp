import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatRadioModule } from '@angular/material/radio';
import { FormsModule } from '@angular/forms';

@NgModule({
  exports: [MatToolbarModule, MatButtonModule, MatRadioModule, FormsModule],
})
export class MaterialModule {}
