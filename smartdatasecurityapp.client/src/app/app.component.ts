import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Renderer2 } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ThemeService } from './theme.service';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];
  // public themeSelect = new FormControl('default');
  constructor(public themeService: ThemeService, private renderer: Renderer2) {}

  ngOnInit() {
    const savedTheme = localStorage.getItem('selectedTheme') || 'theme1';
    this.renderer.setAttribute(document.body, 'class', '');

    this.renderer.addClass(document.body, savedTheme);
  }
}
