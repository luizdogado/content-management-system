import { NgModule, NgModuleFactory, ModuleWithProviders, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { HtmlContentComponent } from './components/html-content.component';
import { HtmlContentRoutingModule } from './html-content-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { CreateHtmlContentComponent } from './components/create-html-content/content-create.component';


@NgModule({
  declarations: [HtmlContentComponent, CreateHtmlContentComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  imports: [
    CoreModule,
    ThemeSharedModule, 
    HtmlContentRoutingModule,
    ReactiveFormsModule,
  ],
  exports: [HtmlContentComponent, CreateHtmlContentComponent],
})
export class HtmlContentModule {
  static forChild(): ModuleWithProviders<HtmlContentModule> {
    return {
      ngModule: HtmlContentModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<HtmlContentModule> {
    return new LazyModuleFactory(HtmlContentModule.forChild());
  }
}
