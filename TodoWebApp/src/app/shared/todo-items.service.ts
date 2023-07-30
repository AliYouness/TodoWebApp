import { TodoItems } from './todo-items.model';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { IfStmt } from '@angular/compiler';

//Front end CRUD methods
@Injectable({
  providedIn: 'root'
})
export class TodoItemService {

  formData: TodoItems = new TodoItems(); 
  readonly baseURL = 'https://localhost:44300/api/controller';
  readonly APIUrl = 'https://localhost:44300/api/controller';
  list: any;

  constructor(private http: HttpClient) { }

  getTodoList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl);
  }

  addTodo(val: TodoItems) {
    console.log(val);
    return this.http.post(this.APIUrl, val);
  }

  updateTodo(Id: string, val: any) {
    return this.http.put(this.APIUrl + '/' + Id, val) ;
  }

  deleteTodo(Id: String) {
    console.log("delete services Id to be deleted ====>>> Id ", Id)
    return this.http.delete(this.APIUrl + '/' + Id);
  }

  //Populates existing records into list property.
  refreshList() {
    return this.http.get(this.APIUrl);
  }

  //Random api call (this one is not using async/await)
  apiCall() {
    return this.http.get('https://localhost:44300/api/controller');
  }
}
