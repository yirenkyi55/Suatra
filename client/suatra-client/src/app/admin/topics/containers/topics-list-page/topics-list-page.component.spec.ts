import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopicsListPageComponent } from './topics-list-page.component';

describe('TopicsListPageComponent', () => {
  let component: TopicsListPageComponent;
  let fixture: ComponentFixture<TopicsListPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TopicsListPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopicsListPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
