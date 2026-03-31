import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateTarefasComponent } from './update-tarefas.component';

describe('UpdateTarefasComponent', () => {
  let component: UpdateTarefasComponent;
  let fixture: ComponentFixture<UpdateTarefasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateTarefasComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateTarefasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
