import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 
import { EquipmentService, Equipment } from '../../services/equipment'; 

@Component({
  selector: 'app-equipment-list',
  standalone: true,
  imports: [CommonModule, FormsModule], 
  templateUrl: './equipment-list.html',
  styleUrl: './equipment-list.css'
})
export class EquipmentListComponent implements OnInit {
  equipos: Equipment[] = [];
  categorias: any[] = [];

  
  nuevoEquipo: Equipment = { id: 0, name: '', equipmentStatus: 'Disponible', pricePerDay: 0, categoryId: 1 };
  editando: boolean = false; 

  constructor(private equipmentService: EquipmentService) {}

  ngOnInit(): void {
    this.cargarEquipos();
    this.cargarCategorias();
  }

  cargarEquipos(): void {
    this.equipmentService.getEquipments().subscribe({
      next: (data: Equipment[]) => this.equipos = data,
      error: (err: any) => console.error('Error:', err)
    });
  }

 guardarEquipo(): void {
    
    if (!this.nuevoEquipo.name || 
        !this.nuevoEquipo.equipmentStatus || 
        !this.nuevoEquipo.pricePerDay || 
        !this.nuevoEquipo.categoryId || 
        this.nuevoEquipo.categoryId === 0) {
      alert('¡Aguanta! Tienes que llenar todos los campos y elegir una categoría. ✋');
      return;
    }

    
    if (this.nuevoEquipo.id && this.nuevoEquipo.id > 0) {
      
     
      this.equipmentService.updateEquipment(this.nuevoEquipo.id, this.nuevoEquipo).subscribe({
        next: (res) => {
          alert('¡Equipo actualizado con éxito! ✏️');
          this.terminarGuardado();
        },
        error: (err) => {
          console.error('Error al actualizar:', err);
          alert('Hubo un error al actualizar.');
        }
      });

    } else {

     
      this.nuevoEquipo.id = 0;
      this.equipmentService.createEquipment(this.nuevoEquipo).subscribe({
        next: (res: any) => {  
          alert('¡Equipo nuevo guardado con éxito! 🏕️');
          this.terminarGuardado();
        },
        error: (err: any) => { 
          console.error('Error al guardar:', err);
          alert('Hubo un error al crear en la base de datos.');
        }
      });

    }
  }

  
  terminarGuardado(): void {
    this.cargarEquipos(); 
   
    this.nuevoEquipo = {
      id: 0,
      name: '',
      equipmentStatus: 'Disponible',
      pricePerDay: 0,
      categoryId: 0 
    };
  }

  
  cargarDatosParaEditar(equipo: Equipment): void {
    this.nuevoEquipo = { ...equipo }; 
    this.editando = true; 
  }

  
  eliminarEquipo(id: number): void {
    if (confirm('¿Estás seguro de que quieres eliminar este equipo? 🚨')) {
      this.equipmentService.deleteEquipment(id).subscribe({
        next: () => {
          alert('¡Equipo eliminado!');
          this.cargarEquipos();
        },
        error: (err) => alert('Error al eliminar')
      });
    }
  }

  limpiarFormulario(): void {
    this.nuevoEquipo = { id: 0, name: '', equipmentStatus: 'Disponible', pricePerDay: 0, categoryId: 1 };
    this.editando = false;
  }

  cargarCategorias(): void {
  this.equipmentService.getCategories().subscribe(data => {
    this.categorias = data;
  });
}
}