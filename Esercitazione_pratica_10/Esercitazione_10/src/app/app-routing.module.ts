import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Pages/home/home.component';
import { CompletedComponent } from './Pages/completed/completed.component';
import { UsersComponent } from './Pages/users/users.component';
import { Page404Component } from './Pages/page404/page404.component';

const routes: Routes = [
  {
    path:"",
    component:HomeComponent,
    title:"Home",
  },
  {
    path:"completed",
    component:CompletedComponent,
    title:"completed",
  },
  {
    path:"users",
    component:UsersComponent,
    title:"users",
  },
  {
    path:"**",
    component:Page404Component,
    title:"Page404",
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
