import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from "@angular/router";
import { StatusService } from '../service/status.service';
import { CreateCategoriaDto } from '../../categorias/models/create-categoria-dto';

@Component({
  selector: 'app-add-status',
  standalone: true,
  imports: [RouterLink, FormsModule],
  templateUrl: './add-status.component.html',
  styleUrl: './add-status.component.css'
})
export class AddStatusComponent {
  private service = inject(StatusService);
  public  create: CreateCategoriaDto = {nome: ''};
  private router = inject(Router);

  onSubmit(): void {
    this.service.createStatus(this.create).subscribe({
      next: () => {
        alert("Status criado com sucesso");
        this.router.navigateByUrl("/status");
      },
      error: (errorObj) => {
        alert(`Erro ao criar status: ${errorObj.error?.errors.Nome}`);
      }
    })
  }
}
