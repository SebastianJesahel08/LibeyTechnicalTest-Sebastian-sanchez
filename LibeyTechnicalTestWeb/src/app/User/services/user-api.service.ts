import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserApiService {
  private baseUrl = 'http://localhost:5023';

  constructor(private http: HttpClient) {}

  list(search?: string): Observable<any[]> {
    const url = search && search.trim().length > 0
      ? `${this.baseUrl}/LibeyUser?search=${encodeURIComponent(search)}`
      : `${this.baseUrl}/LibeyUser`;
    return this.http.get<any[]>(url);
  }

  get(documentNumber: string): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/LibeyUser/${encodeURIComponent(documentNumber)}`);
  }

  create(payload: any): Observable<boolean> {
    return this.http.post<boolean>(`${this.baseUrl}/LibeyUser`, payload);
  }

  update(documentNumber: string, payload: any): Observable<boolean> {
    return this.http.put<boolean>(`${this.baseUrl}/LibeyUser/${encodeURIComponent(documentNumber)}`, payload);
  }

  delete(documentNumber: string): Observable<boolean> {
    return this.http.delete<boolean>(`${this.baseUrl}/LibeyUser/${encodeURIComponent(documentNumber)}`);
  }

  documentTypes(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/DocumentType`);
  }
}
