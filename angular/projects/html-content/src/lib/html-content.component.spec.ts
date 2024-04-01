import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { HtmlContentComponent } from './components/html-content.component';
import { HtmlContentService } from '@html-content';
import { of } from 'rxjs';

describe('HtmlContentComponent', () => {
  let component: HtmlContentComponent;
  let fixture: ComponentFixture<HtmlContentComponent>;
  const mockHtmlContentService = jasmine.createSpyObj('HtmlContentService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [HtmlContentComponent],
      providers: [
        {
          provide: HtmlContentService,
          useValue: mockHtmlContentService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HtmlContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
