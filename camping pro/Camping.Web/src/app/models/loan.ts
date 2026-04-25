export interface Loan {
  id: number;
  customerId: number;
  equipmentId: number;
  loanDate?: string;
  returnDate?: string;
  status: string;
}