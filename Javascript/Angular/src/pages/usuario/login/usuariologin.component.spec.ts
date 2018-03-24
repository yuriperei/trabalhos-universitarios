import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsuariologinComponent } from './usuariologin.component';

describe('UsuariologinComponent', () => {
  let component: UsuariologinComponent;
  let fixture: ComponentFixture<UsuariologinComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsuariologinComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsuariologinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
