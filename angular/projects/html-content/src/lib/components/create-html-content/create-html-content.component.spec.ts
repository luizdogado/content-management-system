import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateHtmlContentComponent } from './create-html-content.component';

describe('CreateHtmlContentComponent', () => {
  let component: CreateHtmlContentComponent;
  let fixture: ComponentFixture<CreateHtmlContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateHtmlContentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateHtmlContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
