import { Component, inject, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceResponse } from '../../../../shared/models/service-response';
import { StatusDto } from '../models/status-dto';
import { StatusService } from '../service/status.service';
import { AsyncPipe } from '@angular/common';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-list-status',
  standalone: true,
  imports: [AsyncPipe, RouterLink],
  templateUrl: './list-status.component.html',
  styleUrl: './list-status.component.css'
})
export class ListStatusComponent implements OnInit {
  public status$!: Observable<ServiceResponse<StatusDto[]>>;
  private service = inject(StatusService);
  
  ngOnInit(): void {
    this.status$ = this.service.getStatus();
  }

  deleteStatusById(id: number): void {
    this.service.deleteStatusById(id).subscribe({
      next: () => {
        this.status$ = this.service.getStatus();
      },
      error: () => {
        alert("Erro ao deletar status");
      }
    })
  }
}
