import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubCategoriesPageComponent } from './sub-categories-page.component';

describe('SubCategoriesPageComponent', () => {
  let component: SubCategoriesPageComponent;
  let fixture: ComponentFixture<SubCategoriesPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubCategoriesPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SubCategoriesPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
