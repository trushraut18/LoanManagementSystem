import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoanService } from '../../../services/loan.service';


@Component({
  selector: 'app-edit-loan',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './edit-loan.html',
  styleUrl: './edit-loan.css',
})
export class EditLoanComponent implements OnInit {
  id = 0;
  amount = 0;
  durationInMonths = 0;
  interestRate = 0;

  constructor( private route: ActivatedRoute, private router: Router, private loanService: LoanService) {}

  ngOnInit() : void
  {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    console.log('Loan Id:', this.id);

    this.loanService.getLoanById(this.id).subscribe({
      next: (response: any) =>
      {
        console.log(response);
        this.amount = response.amount;
        this.durationInMonths = response.durationInMonths;
        this.interestRate = response.interestRate;
      },
      error: (error) =>
      {
        console.error(error);
      }
    });
  }

   updateLoan(): void
  {
    const request = 
    {
      amount: this.amount,
      durationInMonths: this.durationInMonths,
      interestRate: this.interestRate
    };

    this.loanService.updateLoan(this.id, request).subscribe({
      next: () =>
      {
        alert('Loan Updated Successfully');
        this.router.navigate(['/loans']);
      },
      error: (error) =>
      {
        console.error(error);
      }
    });
  }
}
