import { Injectable, Renderer2, RendererFactory2 } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ThemeService {
  private renderer: Renderer2;
  public themeClass: string = 'theme1';

  constructor(rendererFactory: RendererFactory2) {
    this.renderer = rendererFactory.createRenderer(null, null);
    this.renderer.addClass(document.body, this.themeClass);
  }

  setTheme(theme: string): void {
    console.log(theme);
    this.renderer.removeClass(document.body, this.themeClass);
    this.themeClass = theme;
    this.renderer.addClass(document.body, theme);
  }

  getTheme(): string {
    return this.themeClass;
  }
}
