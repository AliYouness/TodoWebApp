import { Component } from '@angular/core';
import { TodoItems } from './shared/todo-items.model';
import { TodoItemService } from './shared/todo-items.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html', 
  styleUrls: ['./app.component.css']
})

export class AppComponent {
 
  title = "todo-items";
  id = "todo-list";
  editDisplay = false;
  showEditButton = false;


  todos: TodoItems[] = [];
  todo: any;


  inputTodo: string = "";
  isDone:Boolean = false;
  

  constructor(private api: TodoItemService, private randomApi: TodoItemService) { 
  }


  ngOnInit(): void {
    this.api.refreshList().subscribe((data: any) => {
      this.todos = data;
    });
  }

  onBlur(todo: TodoItems) {
     this.onEditClick(todo)
  }

  onCheckboxClickTest() {
    this.isDone = !this.isDone;
    console.log('Checkbox clicked - isDone:', this.isDone);
  }

  onCheckBoxClick(event: Event, todo: TodoItems) {
    console.log('Checkbox clicked:', todo);
    console.log('event:', event);
    event.stopPropagation(); 
  }

  onEditClick(todo: TodoItems) {
    this.showEditButton = !this.showEditButton;
    this.title = todo.title;
    this.api.updateTodo(todo.id, todo).subscribe(
      () => {
        console.log('Todo Updated successfully');
      },
      (error) => {
        console.error('Error Updated todo:', error);
      }
    );
    console.log('onEditClick:', todo);
  }

  onDeleteClick(todo: TodoItems) {
    console.log('Delete clicked on object',todo);
    this.todos = this.todos.filter(ob => ob.id !== todo.id);

    this.api.deleteTodo(todo.id).subscribe(
      () => {
        console.log('Todo deleted successfully');
      },
      (error) => {
        console.error('Error deleting todo:', error);
      }
    );
  }

  addTodo() {
    console.log('addTodo', this.isDone);
    this.showEditButton = false;
  
    if (this.inputTodo === "") {
      return null;
    } else {
      this.todo = {
        title: this.inputTodo,
        id: this.generateRandomString(24),
        isDone: this.isDone
      };
  
      this.api.addTodo(this.todo).subscribe((data: any) => {
        this.todos.push({
          id: data.id,
          title: this.inputTodo,
          isDone: this.isDone
        });
        // Clear input after submit
        this.inputTodo = "";
      });
  
      return "pushed to list";
    }
  }

  generateRandomString(length: number) {
    var characters = '0123456789';
    var result = '';
    for (var i = 0; i < length; i++) {
      var randomIndex = Math.floor(Math.random() * characters.length);
      result += characters.charAt(randomIndex);
    }
    return result;
  }

  closeSubmit() {
    this.showEditButton = false;
    this.editDisplay = !this.editDisplay;
  }
}

