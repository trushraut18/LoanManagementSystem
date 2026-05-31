import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Loan } from '../models/loan.model';
import { environment } from '../../environments/environment';
import { CreateLoanRequest } from '../models/create-loan-request.model';
import { UpdateLoanRequest } from '../models/update-loan-request.model';

@Injectable({ providedIn: 'root'})
export class LoanService
{
   private apiUrl = `${environment.apiBaseUrl}/loans`;
   
   constructor( private http: HttpClient){}

   getLoans(): Observable<Loan[]>
   {
    return this.http.get<Loan[]>(`${this.apiUrl}/all`);
   }

   createLoan( request: CreateLoanRequest) 
   {
      return this.http.post(this.apiUrl,request);
   }

   getLoanById( id: number)
   {
      return this.http.get(`${this.apiUrl}/${id}`);

   }

   updateLoan(id: number, request: UpdateLoanRequest)
   {
      return this.http.put(`${this.apiUrl}/${id}`,request);
   }

   deleteLoan(id:number)
   {
      return this.http.delete(`${this.apiUrl}/${id}`);
   }
}