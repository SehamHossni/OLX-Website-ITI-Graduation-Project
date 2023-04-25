import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UploadimageComponent } from './uploadimage.component';

describe('UploadimageComponent', () => {
  let component: UploadimageComponent;
  let fixture: ComponentFixture<UploadimageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UploadimageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UploadimageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
