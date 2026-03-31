import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListTarefasComponent } from './list-tarefas.component';

describe('ListTarefasComponent', () => {
  let component: ListTarefasComponent;
  let fixture: ComponentFixture<ListTarefasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListTarefasComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListTarefasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
