import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './MainComponents/navbar/navbar.component';
import { HomeComponent } from './Pages/home/home.component';
import { CompletedComponent } from './Pages/completed/completed.component';
import { UsersComponent } from './Pages/users/users.component';
import { Page404Component } from './Pages/page404/page404.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    CompletedComponent,
    UsersComponent,
    Page404Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
