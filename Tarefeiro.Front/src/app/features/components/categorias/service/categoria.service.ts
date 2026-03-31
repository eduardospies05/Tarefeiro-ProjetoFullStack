import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceResponse } from '../../../../shared/models/service-response';
import { CategoriaDto } from '../models/categoria-dto';
import { environment } from '../../../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { CreateCategoriaDto } from '../models/create-categoria-dto';
import { UpdateCategoriaDto } from '../models/update-categoria-dto';

@Injectable({
  providedIn: 'root'
})

export class CategoriaService {
  private http = inject(HttpClient);
  private url = `${environment.apiUrl}/Categoria`;

  getCategorias(): Observable<ServiceResponse<CategoriaDto[]>> {
    return this.http.get<ServiceResponse<CategoriaDto[]>>(this.url);
  }

  createCategoria(create: CreateCategoriaDto) : Observable<ServiceResponse<boolean>> {
    return this.http.post<ServiceResponse<boolean>>(this.url, create);
  }

  getCategoriaById(id: number) : Observable<ServiceResponse<CategoriaDto>> {
    return this.http.get<ServiceResponse<CategoriaDto>>(`${this.url}/${id}`);
  }

  updateCategoria(update: UpdateCategoriaDto): Observable<ServiceResponse<boolean>> {
    return this.http.put<ServiceResponse<boolean>>(`${this.url}`, update);
  }

  deleteCategoriaById(id: number) : Observable<ServiceResponse<boolean>> {
    return this.http.delete<ServiceResponse<boolean>>(`${this.url}/${id}`);
  }
}
