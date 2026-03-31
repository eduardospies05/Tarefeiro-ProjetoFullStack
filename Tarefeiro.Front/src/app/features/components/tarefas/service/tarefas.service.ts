import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceResponse } from '../../../../shared/models/service-response';
import { TarefaDto } from '../models/tarefa-dto';
import { environment } from '../../../../../environments/environment.development';
import { CreateTarefaDto } from '../models/create-tarefa-dto';
import { UpdateTarefaDto } from '../models/update-tarefa-dto';

@Injectable({
  providedIn: 'root'
})
export class TarefasService {
  private http = inject(HttpClient);
  private url  = `${environment.apiUrl}/Tarefa`;

  getTarefas(): Observable<ServiceResponse<TarefaDto[]>> {
    return this.http.get<ServiceResponse<TarefaDto[]>>(this.url);
  }

  getTarefaById(id: number): Observable<ServiceResponse<TarefaDto>> {
    return this.http.get<ServiceResponse<TarefaDto>>(`${this.url}/${id}`);
  }

  createTarefa(create: CreateTarefaDto): Observable<ServiceResponse<boolean>> {
    return this.http.post<ServiceResponse<boolean>>(this.url, create);
  }

  updateTarefa(update: UpdateTarefaDto): Observable<ServiceResponse<boolean>> {
    return this.http.put<ServiceResponse<boolean>>(this.url, update);
  }

  deleteTarefaById(id: number): Observable<ServiceResponse<boolean>> {
    return this.http.delete<ServiceResponse<boolean>>(`${this.url}/${id}`);
  }
}
