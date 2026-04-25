import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// Interfaz que representa la clase Equipment de C#
export interface Equipment {
  id: number;
  name: string;
  equipmentStatus: string;
  pricePerDay: number;
  categoryId: number;
}

@Injectable({
  providedIn: 'root'
})
export class EquipmentService {
  
  private apiUrl = 'https://localhost:7022/api/Equipments'; 

  constructor(private http: HttpClient) { }

  getEquipments(): Observable<Equipment[]> {
    return this.http.get<Equipment[]>(this.apiUrl);
  }
}