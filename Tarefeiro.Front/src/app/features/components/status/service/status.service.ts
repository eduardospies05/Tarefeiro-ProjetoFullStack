import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceResponse } from '../../../../shared/models/service-response';
import { StatusDto } from '../models/status-dto';
import { environment } from '../../../../../environments/environment.development';
import { CreateCategoriaDto } from '../../categorias/models/create-categoria-dto';
import { UpdateStatusDto } from '../models/update-status-dto';

@Injectable({
  providedIn: 'root'
})
export class StatusService {
  private http = inject(HttpClient);
  private url = `${environment.apiUrl}/Status`;

  getStatus(): Observable<ServiceResponse<StatusDto[]>> {
    return this.http.get<ServiceResponse<StatusDto[]>>(this.url);
  }

  createStatus(create: CreateCategoriaDto): Observable<ServiceResponse<boolean>> {
    return this.http.post<ServiceResponse<boolean>>(this.url, create);
  }

  updateStatus(update: UpdateStatusDto): Observable<ServiceResponse<boolean>> {
    return this.http.put<ServiceResponse<boolean>>(this.url, update);
  }

  getStatusById(id: number): Observable<ServiceResponse<StatusDto>> {
    return this.http.get<ServiceResponse<StatusDto>>(`${this.url}/${id}`);
  }

  deleteStatusById(id: number): Observable<ServiceResponse<boolean>> {
    return this.http.delete<ServiceResponse<boolean>>(`${this.url}/${id}`);
  }
}
