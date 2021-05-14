import { Component, Input, OnDestroy, OnInit, TemplateRef } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { TodoService } from '../service/todo.service'
import { TodoModel } from '../models/TodoModel';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})



export class TodoComponent implements OnInit, OnDestroy {

  public todoForm: FormGroup;
  public titulo = 'Tarefas';
  public todoSelecionado: TodoModel;
  public textSimple: string;
  Disable : boolean = true;
  public orderby: string = "Prioridade";
  private prioridade: object = {
    Alta: 3,
    Media: 2,
    Baixa: 1
  }



  private unsubscriber = new Subject();

  public todos: TodoModel[];
  public todo: TodoModel;
  public msnDeleteTodo: string;
  public modeSave = 'post';
  private isAsc = true
  private _ORDERBY: object = {
    Prazo: () => {
      this.todos = this.isAsc ? this.todos.sort((a, b) => new Date(a.prazo).getTime() - new Date(b.prazo).getTime()) :
        this.todos.sort((a, b) => new Date(b.prazo).getTime() - new Date(a.prazo).getTime());
    },
    Prioridade: () => {

      this.todos = this.isAsc ? this.todos.sort((a, b) => this.prioridade[a.prioridade] - this.prioridade[b.prioridade]) :
        this.todos.sort((a, b) => this.prioridade[b.prioridade] - this.prioridade[a.prioridade]);
    },
    Completados: () => {
      this.todos = !this.isAsc ? this.todos.sort((a, b) => (a.completado === b.completado) ? 0 : a.completado ? -1 : 1) :
        this.todos.sort((a, b) => (b.completado === a.completado) ? 0 : b.completado ? -1 : 1);
    }
  }

  constructor(
    private todoService: TodoService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) {
    this.criarForm();
  }

  ngOnInit() {
    this.carregarTodos();
   
  }

  ngOnDestroy(): void {
    this.unsubscriber.next();
    this.unsubscriber.complete();
  }

  criarForm() {
    this.todoForm = this.fb.group({
      id: [0],
      descricao: ['', Validators.required],
      prioridade: ['', Validators.required],
      completado: [Boolean, Validators.required],
      prazo: [Date, Validators.required]
    });
  }

  saveTodo() {
    if (this.todoForm.valid) {
      this.spinner.show();

      if (this.modeSave === 'post') {
        this.todo = { ...this.todoForm.value };
      } else {
        this.todo = { id: this.todoSelecionado.id, ...this.todoForm.value };
      }

      this.todoService[this.modeSave](this.todo)
        .pipe(takeUntil(this.unsubscriber))
        .subscribe(
          () => {
            this.carregarTodos();
            this.toastr.success('Tarefa salva com sucesso!');
          }, (error: any) => {
            this.toastr.error(`Erro: Tarefa não pode ser salva!`);
            console.error(error);
          }, () => this.spinner.hide()
        );

    }
  }
  deletarTodo(id: number) {
    this.todoService.delete(id).subscribe(
      (todo: any) => {
        console.log(todo);
        this.toastr.success('Tarefa excluida com sucesso!');
        this.carregarTodos();
      },

      (erro: any) => {
        console.error(erro);
      }
    )
  }

  onChange(event) {
    const type: string = event.target.value;
    if (type !== "Ordenação") {
      this._ORDERBY[type]()
      this.orderby = type
    }

  }

  onChangeRadio(event) {
    const radio = event.target.id
    radio === "asc" ? this.isAsc = true : this.isAsc = false;
    console.log(this.orderby, this.isAsc);
    if (this.orderby !== "")
      this._ORDERBY[this.orderby]();
  }

  carregarTodos() {
    const id = +this.route.snapshot.paramMap.get('id');

    this.spinner.show();
    this.todoService.getAll()
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((todos: TodoModel[]) => {
        this.todos = todos;

        if (id > 0) {
          this.todoSelect(this.todos.find(todo => todo.id === id));
        }

        //this.toastr.success('Tarefas foram carregado com Sucesso!');
      }, (error: any) => {
        this.toastr.error('Tarefas não carregadas!');
        console.log(error);
      }, () => this.spinner.hide()
      );
  }

  todoSelect(todo: TodoModel) {
    this.modeSave = 'put';
    this.todoSelecionado = todo;
    this.todoForm.patchValue(todo);
  }

  
  limpar() {
    this.todoSelecionado = null;
  }
 

}
