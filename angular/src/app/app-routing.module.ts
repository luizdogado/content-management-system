import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateHtmlContentComponent } from 'projects/html-content/src/lib/components/create-html-content/content-create.component';
import { ContentViewComponent } from 'projects/html-content/src/lib/components/view-html-content/content-view.component';

const routes: Routes = [
    {
        path: 'html-content',
        loadChildren: () => import('@html-content')
            .then(m => m.HtmlContentModule.forLazy())
    },

  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  { path: 'content/:id', component: ContentViewComponent },
  { path: 'content', component: CreateHtmlContentComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
