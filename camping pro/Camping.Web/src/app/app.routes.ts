import { Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard';
// Ojo aquí: Ajustamos las rutas para que coincidan con tus carpetas exactas de la foto
import { CustomerListComponent } from './customer-list/customer-list';
import { LoanListComponent } from './loan-list/loan-list';
// Asumo que tu lista de equipos está dentro de components, como se ve arriba en tu foto
import { EquipmentListComponent } from './components/equipment-list/equipment-list'; 

export const routes: Routes = [
  { path: 'inicio', component: DashboardComponent }, // LA NUEVA RUTA
  { path: 'inventario', component: EquipmentListComponent },
  { path: 'clientes', component: CustomerListComponent },
  { path: 'prestamos', component: LoanListComponent },
  { path: '', redirectTo: '/inicio', pathMatch: 'full' } // AHORA REDIRIGE AL INICIO
];