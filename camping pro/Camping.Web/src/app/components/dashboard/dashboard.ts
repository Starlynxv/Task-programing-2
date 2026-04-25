import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

// 1. IMPORTACIONES CORREGIDAS
import { EquipmentService } from '../../services/equipment'; 
import { CustomerService } from '../../services/customer.service';
import { LoanService } from '../../services/loan.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.html'
})
export class DashboardComponent implements OnInit {
  totalEquipos: number = 0;
  equiposDisponibles: number = 0;
  totalClientes: number = 0;
  prestamosActivos: number = 0;

  constructor(
    private equipmentService: EquipmentService,
    private customerService: CustomerService,
    private loanService: LoanService
  ) {}

  ngOnInit(): void {
    
    this.equipmentService.getEquipments().subscribe((data: any[]) => {
      this.totalEquipos = data.length;
      this.equiposDisponibles = data.filter((e: any) => e.equipmentStatus === 'Disponible').length;
    });

    this.customerService.getCustomers().subscribe((data: any[]) => {
      this.totalClientes = data.length;
    });

    this.loanService.getLoans().subscribe((data: any[]) => {
      this.prestamosActivos = data.filter((p: any) => p.status === 'Activo').length;
    });
  }
}