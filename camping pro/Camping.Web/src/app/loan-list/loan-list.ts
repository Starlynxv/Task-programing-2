import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoanService } from '../services/loan.service';
import { CustomerService } from '../services/customer.service';
import { EquipmentService } from '../services/equipment';
import { Loan } from '../models/loan';
import { Customer } from '../models/customer';
import { Equipment } from '../models/equipment';

@Component({
  selector: 'app-loan-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './loan-list.html'
})
export class LoanListComponent implements OnInit {
  prestamos: Loan[] = [];
  clientes: Customer[] = [];
  equipos: Equipment[] = [];
  
  
  nuevoPrestamo: Loan = { id: 0, customerId: 0, equipmentId: 0, status: 'Activo' };

  constructor(
    private loanService: LoanService,
    private customerService: CustomerService,
    private equipmentService: EquipmentService
  ) {}

  ngOnInit(): void {
    this.cargarDatos();
  }

  cargarDatos(): void {
   
    this.loanService.getLoans().subscribe(data => this.prestamos = data);
    this.customerService.getCustomers().subscribe(data => this.clientes = data);
    this.equipmentService.getEquipments().subscribe(data => this.equipos = data);
  }

  guardarPrestamo(): void {
    if (this.nuevoPrestamo.customerId === 0 || this.nuevoPrestamo.equipmentId === 0) {
      alert('Por favor selecciona un cliente y un equipo.');
      return;
    }

    this.loanService.addLoan(this.nuevoPrestamo).subscribe({
      next: () => {
        alert('¡Préstamo registrado con éxito!');
        this.nuevoPrestamo = { id: 0, customerId: 0, equipmentId: 0, status: 'Activo' };
        this.cargarDatos(); // Recargar para actualizar los estados
      },
      error: (err) => alert(err.error || 'Error al procesar el préstamo. Verifica que el equipo esté disponible.')
    });
  }

  devolver(id: number): void {
    
    if (confirm('¿Confirmas que el cliente devolvió este equipo?')) {
      
      
      const tieneDanos = confirm('🚨 INSPECCIÓN: ¿El equipo presenta algún DAÑO? \n\n[Aceptar] = Está Roto \n[Cancelar] = Está Perfecto');

      
      this.loanService.devolverEquipo(id, tieneDanos).subscribe({
        next: () => {
          if (tieneDanos) {
            alert('🛠️ Equipo devuelto y marcado como DAÑADO. Pasado a mantenimiento.');
          } else {
            alert('✅ ¡Equipo devuelto en perfectas condiciones!');
          }
          this.cargarDatos(); 
        },
        error: (err) => alert('Error al devolver el equipo.')
      });
    }
  }
  

 
  obtenerNombreCliente(id: number): string {
    const cliente = this.clientes.find(c => c.id === id);
    return cliente ? `${cliente.firstName} ${cliente.lastName}` : 'Desconocido';
  }

  obtenerNombreEquipo(id: number): string {
    const equipo = this.equipos.find(e => e.id === id);
    return equipo ? equipo.name : 'Desconocido';
  }
}