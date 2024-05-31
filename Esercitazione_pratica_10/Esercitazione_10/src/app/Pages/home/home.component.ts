import { Component } from '@angular/core';
import { TodoService } from '../../Services/todo.service';
import { UserService } from '../../Services/user.service';
import { iTodo } from '../../Modules/itodo';
import { iUser } from '../../Modules/iuser';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  todoArr:iTodo[]=[]
  userArr:iUser[]=[]
  todoConUser:iTodo[]=[]
  user:string=""

  constructor(
    private todoSvc:TodoService,
    private userSvc:UserService
  ){}

  ngOnInit(){

    this.todoArr=this.todoSvc.toDo
    this.userArr=this.userSvc.user

    this.getTodoConUser(this.userArr) //Ho rimosso user dai parametri non avendo completato la task


   /* this.todoConUser=this.todoArr.map(t=>{
    let user=this.userArr.find(u=>u.id==t.userId);
    t.user=user;
    return t
  })

  console.log(this.todoConUser)*/
  }

  getTodoConUser(userArr:iUser[],user?:string){
      this.todoConUser=this.todoSvc.getTodoConUser(userArr) //Ho rimosso user dai parametri non avendo completato la task
    }

}


