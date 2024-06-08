import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { ProfileComponent } from './profile/profile.component';
import { AllUserComponent } from './all-user/all-user.component';
import { FavouriteComponent } from './favourite/favourite.component';

const routes: Routes = [
  { path: '', component: DashboardComponent },
  { path: 'profilo', component: ProfileComponent },
  { path: 'allUser', component: AllUserComponent },
  { path: 'favourite', component: FavouriteComponent }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
