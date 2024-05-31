import { Component } from '@angular/core';
import { iTodo } from '../../Modules/itodo';
import { iUser } from '../../Modules/iuser';
import { TodoService } from '../../Services/todo.service';
import { UserService } from '../../Services/user.service';

@Component({
  selector: 'app-completed',
  templateUrl: './completed.component.html',
  styleUrl: './completed.component.scss'
})
export class CompletedComponent {

  todoArr:iTodo[]=[]
  userArr:iUser[]=[]
  todoConUser:iTodo[]=[]
  todoCompleted:iTodo[]=[]

  constructor(
    private todoSvc:TodoService,
    private userSvc:UserService
  ){}

  ngOnInit(){

    this.todoArr=this.todoSvc.toDo
    this.userArr=this.userSvc.user

    this.getTodoCompleted(this.userArr)

    /* this.todoConUser=this.todoArr.map(t=>{
    let user=this.userArr.find(u=>u.id==t.userId);
    t.user=user;
    return t
  })

  this.todoCompleted=this.todoConUser.filter(todo=>todo.completed===true)

  console.log(this.todoCompleted) */
  }

  getTodoCompleted(userArr:iUser[]){
    this.todoCompleted=this.todoSvc.getTodoCompleted(userArr)
  }

}

