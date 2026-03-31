import { Component, inject, OnInit } from '@angular/core';
import { TarefasService } from '../service/tarefas.service';
import { Observable } from 'rxjs';
import { ServiceResponse } from '../../../../shared/models/service-response';
import { TarefaDto } from '../models/tarefa-dto';
import { AsyncPipe } from '@angular/common';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-list-tarefas',
  standalone: true,
  imports: [AsyncPipe, RouterLink],
  templateUrl: './list-tarefas.component.html',
  styleUrl: './list-tarefas.component.css'
})
export class ListTarefasComponent implements OnInit {
  private service = inject(TarefasService);
  public tarefas$!: Observable<ServiceResponse<TarefaDto[]>>;
  
  ngOnInit(): void {
    this.tarefas$ = this.service.getTarefas();
  }

  onDelete(id: number): void {
    this.service.deleteTarefaById(id).subscribe({
      next: () => {
        this.tarefas$ = this.service.getTarefas();
      },
      error: () => {
        alert("Erro ao deletar registro");
      }
    })
  }
}
