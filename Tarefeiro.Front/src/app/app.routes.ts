import { Routes } from '@angular/router';
import { ListCategoriasComponent } from './features/components/categorias/list-categorias/list-categorias.component';
import { AddCategoriasComponent } from './features/components/categorias/add-categorias/add-categorias.component';
import { UpdateCategoriasComponent } from './features/components/categorias/update-categorias/update-categorias.component';
import { ListStatusComponent } from './features/components/status/list-status/list-status.component';
import { AddStatusComponent } from './features/components/status/add-status/add-status.component';
import { UpdateStatusComponent } from './features/components/status/update-status/update-status.component';
import { ListTarefasComponent } from './features/components/tarefas/list-tarefas/list-tarefas.component';
import { AddTarefasComponent } from './features/components/tarefas/add-tarefas/add-tarefas.component';
import { UpdateTarefasComponent } from './features/components/tarefas/update-tarefas/update-tarefas.component';

export const routes: Routes = [
    {path: "categorias", component: ListCategoriasComponent},
    {path: "categorias/add", component: AddCategoriasComponent},
    {path: "categorias/edit/:id", component: UpdateCategoriasComponent},
    {path: "status", component: ListStatusComponent},
    {path: "status/add", component: AddStatusComponent},
    {path: "status/edit/:id", component: UpdateStatusComponent},
    {path: "tarefas", component: ListTarefasComponent},
    {path: "tarefas/add", component: AddTarefasComponent},
    {path: "tarefas/edit/:id", component: UpdateTarefasComponent},
    {path: "", redirectTo: "tarefas", pathMatch: 'full'}
];
