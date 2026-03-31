import { Component, inject, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceResponse } from '../../../../shared/models/service-response';
import { CategoriaDto } from '../models/categoria-dto';
import { CategoriaService } from '../service/categoria.service';
import { AsyncPipe } from '@angular/common';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-list-categorias',
  standalone: true,
  imports: [AsyncPipe, RouterLink],
  templateUrl: './list-categorias.component.html',
  styleUrl: './list-categorias.component.css'
})
export class ListCategoriasComponent implements OnInit {
  public categorias$!: Observable<ServiceResponse<CategoriaDto[]>>;
  private service = inject(CategoriaService);
  
  ngOnInit(): void {
    this.categorias$ = this.service.getCategorias();
  }

  deleteCategoriaById(id: number): void {
    this.service.deleteCategoriaById(id).subscribe({
      next: () => {
        this.categorias$ = this.service.getCategorias();
      },
      error: () => {
        alert("Não foi possivel deletar esta categoria");
      }
    });
  }
}
