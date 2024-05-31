import { Component } from '@angular/core';
import { iTodo } from '../../Modules/itodo';
import { iUser } from '../../Modules/iuser';
import { TodoService } from '../../Services/todo.service';
import { UserService } from '../../Services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss'
})
export class UsersComponent {
  todoArr:iTodo[]=[]
  userArr:iUser[]=[]
  userConTodo:iUser[]=[]

  constructor(
    private todoSvc:TodoService,
    private userSvc:UserService
  ){}

  ngOnInit(){

    this.todoArr=this.todoSvc.toDo
    this.userArr=this.userSvc.user

    this.userConTodo = this.userArr.map(u => {
      let allTodo = this.todoArr.filter(t => t.userId === u.id);
      u.Alltodo = allTodo;
      return u;
    });

    console.log(this.userConTodo);
}
}
