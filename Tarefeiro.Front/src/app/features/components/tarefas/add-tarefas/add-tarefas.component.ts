import { Component, inject, OnInit } from '@angular/core';
import { TarefasService } from '../service/tarefas.service';
import { Observable } from 'rxjs';
import { StatusDto } from '../../status/models/status-dto';
import { ServiceResponse } from '../../../../shared/models/service-response';
import { CategoriaDto } from '../../categorias/models/categoria-dto';
import { StatusService } from '../../status/service/status.service';
import { CategoriaService } from '../../categorias/service/categoria.service';
import { AsyncPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from "@angular/router";
import { CreateTarefaDto } from '../models/create-tarefa-dto';

@Component({
  selector: 'app-add-tarefas',
  standalone: true,
  imports: [AsyncPipe, FormsModule, RouterLink, FormsModule],
  templateUrl: './add-tarefas.component.html',
  styleUrl: './add-tarefas.component.css'
})
export class AddTarefasComponent implements OnInit {
  private service = inject(TarefasService);
  private statusService = inject(StatusService);
  private categoriaService = inject(CategoriaService);
  public  status$!: Observable<ServiceResponse<StatusDto[]>>;
  public  categorias$!: Observable<ServiceResponse<CategoriaDto[]>>;
  public  create: CreateTarefaDto = {statusId: 0, categoriaId: 0, comentario: ''};
  private router = inject(Router);

  ngOnInit(): void {
    this.status$ = this.statusService.getStatus();
    this.categorias$ = this.categoriaService.getCategorias();
  }

  onSubmit(): void {
    this.service.createTarefa(this.create).subscribe({
      next: () => {
        alert("Tarefa criada com sucesso");
        this.router.navigateByUrl("/tarefas");
      },
      error: (errorObj) => {
        alert(`Erro ao criar tarefa`);
      }
    })
  }
}
