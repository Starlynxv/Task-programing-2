import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { FormsModule } from '@angular/forms';   
import { CustomerService } from '../services/customer.service';
import { Customer } from '../models/customer';

@Component({
  selector: 'app-customer-list',
  standalone: true,                      
  imports: [CommonModule, FormsModule],  
  templateUrl: './customer-list.html'    
})

  
export class CustomerListComponent implements OnInit {
  clientes: Customer[] = [];
  nuevoCliente: Customer = { id: 0, firstName: '', lastName: '', phone: '', email: '' };

  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {
    this.cargarClientes();
  }

  cargarClientes(): void {
    this.customerService.getCustomers().subscribe(data => this.clientes = data);
  }

  guardarCliente(): void {
    this.customerService.addCustomer(this.nuevoCliente).subscribe(() => {
      alert('¡Cliente guardado!');
      this.cargarClientes();
      this.nuevoCliente = { id: 0, firstName: '', lastName: '', phone: '', email: '' }; 
    });
  }
}