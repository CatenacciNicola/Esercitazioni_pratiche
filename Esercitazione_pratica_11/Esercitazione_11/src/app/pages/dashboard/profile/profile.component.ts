import { Component } from '@angular/core';
import { iUser } from '../../../models/i-user';
import { AuthService } from '../../../auth/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss'
})
export class ProfileComponent {

  user:iUser|null=null;

  constructor(private userSvc:AuthService) {}

  ngOnInit():void{
    this.userSvc.getCurrentUser().subscribe(user=>{
      this.user=user;
    });
  }

}
