import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChatshomeallComponent } from './chatshomeall.component';

describe('ChatshomeallComponent', () => {
  let component: ChatshomeallComponent;
  let fixture: ComponentFixture<ChatshomeallComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChatshomeallComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChatshomeallComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
