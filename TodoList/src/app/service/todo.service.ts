import { Injectable } from '@angular/core';
import { TodoModel } from '../models/TodoModel';
import { HttpClient} from "@angular/common/http";
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class TodoService {
  baseURL = `${environment.mainUrlAPI}todo`;
  
  constructor(private http: HttpClient) { }

  getAll(): Observable<TodoModel[]> {
    return this.http.get<TodoModel[]>(this.baseURL);
  }

  getById(id: number): Observable<TodoModel> {
    return this.http.get<TodoModel>(`${this.baseURL}/${id}`);
  }

  post(todo: TodoModel) {
    return this.http.post(this.baseURL, todo);
  }

  put(todo: TodoModel) {
    return this.http.put(`${this.baseURL}/${todo.id}`, todo);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

}