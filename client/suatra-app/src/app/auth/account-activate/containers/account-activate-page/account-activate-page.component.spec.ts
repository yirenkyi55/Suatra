import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountActivatePageComponent } from './account-activate-page.component';

describe('AccountActivatePageComponent', () => {
  let component: AccountActivatePageComponent;
  let fixture: ComponentFixture<AccountActivatePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccountActivatePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountActivatePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
