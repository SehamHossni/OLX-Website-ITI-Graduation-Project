import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateprodinfoComponent } from './updateprodinfo.component';

describe('UpdateprodinfoComponent', () => {
  let component: UpdateprodinfoComponent;
  let fixture: ComponentFixture<UpdateprodinfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateprodinfoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateprodinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
