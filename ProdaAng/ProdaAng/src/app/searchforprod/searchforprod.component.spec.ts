import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchforprodComponent } from './searchforprod.component';

describe('SearchforprodComponent', () => {
  let component: SearchforprodComponent;
  let fixture: ComponentFixture<SearchforprodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchforprodComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchforprodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
