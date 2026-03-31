import { Component, inject, OnInit } from '@angular/core';
import { TarefasService } from '../service/tarefas.service';
import { Observable } from 'rxjs';
import { ServiceResponse } from '../../../../shared/models/service-response';
import { TarefaDto } from '../models/tarefa-dto';
import { UpdateTarefaDto } from '../models/update-tarefa-dto';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { StatusService } from '../../status/service/status.service';
import { CategoriaService } from '../../categorias/service/categoria.service';
import { StatusDto } from '../../status/models/status-dto';
import { setThrowInvalidWriteToSignalError } from '@angular/core/primitives/signals';
import { CategoriaDto } from '../../categorias/models/categoria-dto';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-update-tarefas',
  standalone: true,
  imports: [FormsModule, AsyncPipe, RouterLink],
  templateUrl: './update-tarefas.component.html',
  styleUrl: './update-tarefas.component.css'
})
export class UpdateTarefasComponent implements OnInit {
  private service = inject(TarefasService);
  private statusService = inject(StatusService);
  private categoriaService = inject(CategoriaService);
  public  tarefas$!: Observable<ServiceResponse<TarefaDto>>;
  public  status$!: Observable<ServiceResponse<StatusDto[]>>;
  public  categorias$!: Observable<ServiceResponse<CategoriaDto[]>>;
  public  update: UpdateTarefaDto = {id: 0, statusId: 0, categoriaId: 0, comentario: ''};
  private router = inject(Router);
  private url = inject(ActivatedRoute);
  
  ngOnInit(): void {
    const id = Number(this.url.snapshot.paramMap.get('id'));

    this.status$ = this.statusService.getStatus();
    this.categorias$ = this.categoriaService.getCategorias();

    if(id) {
      this.tarefas$ = this.service.getTarefaById(id);

      this.tarefas$.subscribe({
        next: (response) => {
          if(response.status && response.data) {
            this.update = {
              id: response.data.id,
              statusId: response.data.status.id,
              categoriaId: response.data.categoria.id,
              comentario: response.data.comentario
            };
          }
        },
        error: () => {
          alert("Tarefa inexistente");
          this.router.navigateByUrl("/tarefas");
        }
      })
    }
  }

  onSubmit(): void {
    this.service.updateTarefa(this.update).subscribe({
      next: (response) => {
        if(response.status && response.data)
          alert("Tarefa atualizada com sucesso");
        this.router.navigateByUrl("/tarefas");
      },
      error: () => {
        alert("Erro ao atualizar tarefa");
      }
    });
  }
}
