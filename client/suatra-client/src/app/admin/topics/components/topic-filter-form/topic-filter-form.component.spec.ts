import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopicFilterFormComponent } from './topic-filter-form.component';

describe('TopicFilterFormComponent', () => {
  let component: TopicFilterFormComponent;
  let fixture: ComponentFixture<TopicFilterFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TopicFilterFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopicFilterFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
