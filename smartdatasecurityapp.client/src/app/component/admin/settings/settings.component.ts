import { Component, OnInit, Renderer2 } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // Import this module
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatGridListModule } from '@angular/material/grid-list';
import { ThemeService } from '../../../theme.service';
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-settings',
  imports: [
    MatFormFieldModule,
    MatSelectModule,
    CommonModule,
    FormsModule,
    MatGridListModule,
    ReactiveFormsModule,
    MatButton,
  ],
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.css',
})
export class SettingsComponent implements OnInit {
  themes = ['theme1', 'theme2']; // Define available themes
  public themeSelect = new FormControl('theme1');
  constructor(public themeService: ThemeService, private renderer: Renderer2) {}

  ngOnInit(): void {
    // Retrieve the saved theme from localStorage or fallback to default
    const savedTheme = localStorage.getItem('selectedTheme') || 'theme1';
    console.log(savedTheme);
    this.themeSelect.setValue(savedTheme);
    this.themeService.setTheme(savedTheme); // Apply saved theme
    this.renderer.addClass(document.body, savedTheme);

    // Subscribe to form control value changes
    this.themeSelect.valueChanges.subscribe((theme) => {
      this.onThemeChange(theme);
    });
  }
  onThemeChange(event: any): void {
    const savedTheme = localStorage.getItem('selectedTheme') || 'theme1';
    this.renderer.removeClass(document.body, savedTheme?.toString());
    this.renderer.addClass(document.body, event.value);

    this.themeService.setTheme(event.value); // Apply new theme
    localStorage.setItem('selectedTheme', event.value);
  }
}
