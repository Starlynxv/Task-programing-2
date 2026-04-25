import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Loan } from '../models/loan';

@Injectable({
  providedIn: 'root'
})
export class LoanService {
  private apiUrl = 'https://localhost:7022/api/Loans'; 

  constructor(private http: HttpClient) { }

  getLoans(): Observable<Loan[]> {
    return this.http.get<Loan[]>(this.apiUrl);
  }

  // Registrar un préstamo nuevo
  addLoan(loan: Loan): Observable<any> {
    return this.http.post(this.apiUrl, loan);
  }

  // Devolver el equipo (Ahora avisa si hay daños)
  devolverEquipo(id: number, conDanos: boolean): Observable<any> {
    return this.http.put(`${this.apiUrl}/Devolver/${id}?conDanos=${conDanos}`, {});
  }
}