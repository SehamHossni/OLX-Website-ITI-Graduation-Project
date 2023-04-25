import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavheaderbarComponent } from './navheaderbar.component';

describe('NavheaderbarComponent', () => {
  let component: NavheaderbarComponent;
  let fixture: ComponentFixture<NavheaderbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavheaderbarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NavheaderbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
