import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from "@angular/router";
import { CategoriaService } from '../service/categoria.service';
import { CreateCategoriaDto } from '../models/create-categoria-dto';

@Component({
  selector: 'app-add-categorias',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './add-categorias.component.html',
  styleUrl: './add-categorias.component.css'
})
export class AddCategoriasComponent {
  private service = inject(CategoriaService);
  public  create: CreateCategoriaDto = {nome: ''};
  private  router = inject(Router);

  onSubmit(): void {
    this.service.createCategoria(this.create).subscribe({
      next: () => {
        alert("Categoria criada com sucesso");
        this.router.navigateByUrl("/categorias");
      },
      error: (err) => {
        alert(`Erro ao criar categoria: ${err.error?.errors.Nome}`);
      }
    })
  }
}
