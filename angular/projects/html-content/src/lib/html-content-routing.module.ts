import { NgModule } from '@angular/core';
import { RouterOutletComponent } from '@abp/ng.core';
import { Routes, RouterModule } from '@angular/router';
import { HtmlContentComponent } from './components/html-content.component';
import { HttpClientModule } from '@angular/common/http';
import { ContentViewComponent } from './components/view-html-content/content-view.component';
const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: RouterOutletComponent,
    children: [
      {
        path: '',
        component: HtmlContentComponent,
      },
    ],
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes), HttpClientModule],
  exports: [RouterModule],
})
export class HtmlContentRoutingModule {}
