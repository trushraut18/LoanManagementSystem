import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoanService } from '../../../services/loan.service'; 
import { Loan } from '../../../models/loan.model';
import { ChangeDetectorRef } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-loan-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './loan-list.html',
  styleUrl: './loan-list.css',
})
export class LoanListComponent implements OnInit {
  loans: Loan[] = [];

  constructor( private loanService: LoanService, private cdr: ChangeDetectorRef){}

  ngOnInit(): void {
    this.loadLoans();
  }

  loadLoans(): void
  {
    this.loanService.getLoans().subscribe({
next: (response) =>
{
     console.log('API Response:', response);
    this.loans = response;
    console.log('Loans After Assignment:', this.loans);
    this.cdr.detectChanges();

},

      error: (error) =>
      {
        console.error(error);
      }
    });
  }

  deleteLoan(id: number): void
  {
    if(!confirm("Are you sure ?"))
    {
      return;
    }
    this.loanService.deleteLoan(id).subscribe({
      next: () =>
      {
        alert('Loan Deleted');
        this.loadLoans();
      },

      error: (error) =>
      {
        console.error(error);
      }
    });
  }
}
