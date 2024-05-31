import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './MainComponents/navbar/navbar.component';
import { HomeComponent } from './Pages/home/home.component';
import { CompletedComponent } from './Pages/completed/completed.component';
import { UsersComponent } from './Pages/users/users.component';
import { Page404Component } from './Pages/page404/page404.component';
import { SingleTodoComponent } from './MainComponents/single-todo/single-todo.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    CompletedComponent,
    UsersComponent,
    Page404Component,
    SingleTodoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
