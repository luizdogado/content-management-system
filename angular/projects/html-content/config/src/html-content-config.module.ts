import { ModuleWithProviders, NgModule } from '@angular/core';
import { HTML_CONTENT_ROUTE_PROVIDERS } from './providers/route.provider';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule()
export class HtmlContentConfigModule {
  static forRoot(): ModuleWithProviders<HtmlContentConfigModule> {
    return {
      ngModule: HtmlContentConfigModule,
      providers: [HTML_CONTENT_ROUTE_PROVIDERS],
    };
  }
}
