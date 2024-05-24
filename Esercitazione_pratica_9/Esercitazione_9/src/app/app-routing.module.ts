import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrandComponent } from './pages/brand/brand.component';
import { HomeComponent } from './pages/home/home.component';
import { Page404Component } from './pages/page404/page404.component';

const routes: Routes = [
  {
    path:"",
    component:HomeComponent,
    title:"Home",
    pathMatch:"full"
  },
  {
    path:"brand/:brand",
    component:BrandComponent,
    title:"Brand",
  },
  {
    path:"**",
    component:Page404Component,
    title:"404"
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
