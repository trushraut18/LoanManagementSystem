import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { LoanService } from '../../../services/loan.service';
@Component({
  selector: 'app-create-loan',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './create-loan.html',
  styleUrl: './create-loan.css',
})
export class CreateLoanComponent {

  amount = 0;
  durationInMonths = 0;
  interestRate=0;

  constructor(private loanService : LoanService, private router: Router ){}

  createLoan()
  {
    const request = 
    {
      amount: this.amount,
      durationInMonths: this.durationInMonths,
      interestRate: this.interestRate
    };

    console.log(request);

    this.loanService.createLoan(request).subscribe({
      next: () =>
      {
        alert('Loan created successfully');
        this.router.navigate(['/loans']);
      },
      error:(error) =>
      {
        console.error(error);
      }
    });
  }
}
