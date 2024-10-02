import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarMatComponent } from './agregar-mat.component';

describe('AgregarMatComponent', () => {
  let component: AgregarMatComponent;
  let fixture: ComponentFixture<AgregarMatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AgregarMatComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AgregarMatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
