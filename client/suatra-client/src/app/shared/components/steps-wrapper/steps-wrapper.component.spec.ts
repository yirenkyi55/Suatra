import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StepsWrapperComponent } from './steps-wrapper.component';

describe('StepsWrapperComponent', () => {
  let component: StepsWrapperComponent;
  let fixture: ComponentFixture<StepsWrapperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StepsWrapperComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StepsWrapperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
