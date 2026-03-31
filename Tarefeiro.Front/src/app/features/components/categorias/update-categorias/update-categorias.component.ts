import { Component, inject, OnInit } from '@angular/core';
import { CategoriaService } from '../service/categoria.service';
import { UpdateCategoriaDto } from '../models/update-categoria-dto';
import { Observable } from 'rxjs';
import { ServiceResponse } from '../../../../shared/models/service-response';
import { CategoriaDto } from '../models/categoria-dto';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-update-categorias',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './update-categorias.component.html',
  styleUrl: './update-categorias.component.css'
})
export class UpdateCategoriasComponent implements OnInit {
  private service = inject(CategoriaService);
  private urlId = inject(ActivatedRoute);
  public update: UpdateCategoriaDto = { id: 0, nome: '' };
  public categorias$!: Observable<ServiceResponse<CategoriaDto>>;
  private route = inject(Router);

  ngOnInit(): void {
    const id = Number(this.urlId.snapshot.paramMap.get("id"));

    if (id) {
      this.categorias$ = this.service.getCategoriaById(id);

      this.categorias$.subscribe({
        next: (res) => {
          if(res.data)
            this.update = res.data;
        }, error: (err) => {
          alert("Categoria não encontrada");
          this.route.navigateByUrl("/categorias");
        }
      });
    }
  }

  onSubmit(): void {
    this.service.updateCategoria(this.update).subscribe({
      next: () => {
        alert("Categoria atualizada com sucesso");
        this.route.navigateByUrl("/categorias");
      },
      error: (errorObj) => {
        alert(`Erro ao atualizar categoria: ${errorObj.error?.errors.Nome}`);
      }
    })
  }
}
