import { Component } from '@angular/core';
import { AuthService } from '../../../auth/auth.service';
import { iUser } from '../../../models/i-user';

@Component({
  selector: 'app-all-user',
  templateUrl: './all-user.component.html',
  styleUrl: './all-user.component.scss'
})
export class AllUserComponent {

  allUsers: iUser[]=[]

  constructor(private userSvc:AuthService)
  {this.userSvc.getAllUsers().subscribe(users=>{
    this.allUsers=users
  })}
}
