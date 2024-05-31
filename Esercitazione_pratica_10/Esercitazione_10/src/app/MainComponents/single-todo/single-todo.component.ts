import { iTodo } from './../../Modules/itodo';
import { Component, Input, input } from '@angular/core';

@Component({
  selector: 'app-single-todo',
  templateUrl: './single-todo.component.html',
  styleUrl: './single-todo.component.scss'
})
export class SingleTodoComponent {

  @Input() todo!:iTodo

  toggleStatus(){
    this.todo.completed=!this.todo.completed
  }
}
