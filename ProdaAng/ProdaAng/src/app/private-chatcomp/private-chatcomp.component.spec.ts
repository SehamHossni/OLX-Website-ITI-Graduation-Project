import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrivateChatcompComponent } from './private-chatcomp.component';

describe('PrivateChatcompComponent', () => {
  let component: PrivateChatcompComponent;
  let fixture: ComponentFixture<PrivateChatcompComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrivateChatcompComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrivateChatcompComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
