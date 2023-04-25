import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatigorypageComponent } from './catigorypage.component';

describe('CatigorypageComponent', () => {
  let component: CatigorypageComponent;
  let fixture: ComponentFixture<CatigorypageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CatigorypageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CatigorypageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
