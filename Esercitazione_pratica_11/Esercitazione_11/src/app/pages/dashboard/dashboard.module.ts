import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { ProfileComponent } from './profile/profile.component';
import { AllUserComponent } from './all-user/all-user.component';
import { FavouriteComponent } from './favourite/favourite.component';


@NgModule({
  declarations: [
    DashboardComponent,
    ProfileComponent,
    AllUserComponent,
    FavouriteComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule
  ]
})
export class DashboardModule { }
