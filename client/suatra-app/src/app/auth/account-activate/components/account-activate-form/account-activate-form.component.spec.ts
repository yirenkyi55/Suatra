import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountActivateFormComponent } from './account-activate-form.component';

describe('AccountActivateFormComponent', () => {
  let component: AccountActivateFormComponent;
  let fixture: ComponentFixture<AccountActivateFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccountActivateFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountActivateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
