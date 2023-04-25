import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewproductComponent } from './add-newproduct.component';

describe('AddNewproductComponent', () => {
  let component: AddNewproductComponent;
  let fixture: ComponentFixture<AddNewproductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddNewproductComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddNewproductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
