export interface Loan
{
    id: number;
    amount: number;
    durationInMonths: number;
    interestRate: number;
    status: string;
    userId: number;
}