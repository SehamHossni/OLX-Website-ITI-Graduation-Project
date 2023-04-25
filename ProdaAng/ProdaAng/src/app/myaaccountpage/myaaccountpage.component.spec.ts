import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyaaccountpageComponent } from './myaaccountpage.component';

describe('MyaaccountpageComponent', () => {
  let component: MyaaccountpageComponent;
  let fixture: ComponentFixture<MyaaccountpageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyaaccountpageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyaaccountpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
