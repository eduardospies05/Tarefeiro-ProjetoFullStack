import { Component, inject, OnInit } from '@angular/core';
import { UpdateStatusDto } from '../models/update-status-dto';
import { StatusService } from '../service/status.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { StatusDto } from '../models/status-dto';
import { ServiceResponse } from '../../../../shared/models/service-response';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-update-status',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './update-status.component.html',
  styleUrl: './update-status.component.css'
})
export class UpdateStatusComponent implements OnInit {
  public update: UpdateStatusDto = { id: 0, nome: '' };
  private service = inject(StatusService);
  private router = inject(Router);
  public status$!: Observable<ServiceResponse<StatusDto>>;
  private urlInfo = inject(ActivatedRoute);

  ngOnInit(): void {
    const id = Number(this.urlInfo.snapshot.paramMap.get("id"));

    if (id) {
      this.status$ = this.service.getStatusById(id);

      this.status$.subscribe({
        next: (res) => {
          console.log(res);
          if (res.data && res.status == true) {
            this.update = { id: res.data.id, nome: res.data.nome };
            return;
          }
          alert("Status não encontrado");
          this.router.navigateByUrl("/status");
        }, error: (err) => {
          alert("Status não encontrado");
          this.router.navigateByUrl("/status");
        }
      })
    }
  }

  onSubmit(): void {
    this.service.updateStatus(this.update).subscribe({
      next: (res) => {
        if(res.status == true) {
          alert("Status atualizado com sucesso");
          this.router.navigateByUrl("/status");
        }
      },
      error: (errorObj) => {
        alert(`Erro ao atualizar status: ${errorObj.error?.errors.Nome}`);
      }
    })
  }
}