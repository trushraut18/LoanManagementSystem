export interface CreateLoanRequest
{
    amount: number;

    durationInMonths: number;

    interestRate: number;
}