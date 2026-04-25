import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

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

  
  addEquipment(equipo: Equipment): Observable<Equipment> {
    return this.http.post<Equipment>(this.apiUrl, equipo);
  }
  
  updateEquipment(id: number, equipo: Equipment): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, equipo);
  }

  
  deleteEquipment(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  // Pedir la lista de categorías al API
  getCategories(): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:7022/api/Categories');
  }

  // Agrega esto en tu equipment.service.ts
  createEquipment(equipo: any): Observable<any> {
    return this.http.post<any>('https://localhost:7022/api/Equipments', equipo);
  }
}