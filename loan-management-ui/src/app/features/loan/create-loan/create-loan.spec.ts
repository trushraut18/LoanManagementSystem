import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateLoan } from './create-loan';

describe('CreateLoan', () => {
  let component: CreateLoan;
  let fixture: ComponentFixture<CreateLoan>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateLoan],
    }).compileComponents();

    fixture = TestBed.createComponent(CreateLoan);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
