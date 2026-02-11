import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { LibeyUser } from "src/app/entities/libeyuser";

@Injectable({
  providedIn: "root",
})
export class LibeyUserService {
  constructor(private http: HttpClient) {}

  private baseUrl(): string {
    return environment.pathLibeyTechnicalTest;
  }

  Find(documentNumber: string): Observable<LibeyUser> {
    const uri = `${this.baseUrl()}LibeyUser/${encodeURIComponent(documentNumber)}`;
    return this.http.get<LibeyUser>(uri);
  }

  List(search?: string): Observable<any[]> {
    const uri =
      search && search.trim().length > 0
        ? `${this.baseUrl()}LibeyUser?search=${encodeURIComponent(search)}`
        : `${this.baseUrl()}LibeyUser`;
    return this.http.get<any[]>(uri);
  }

  Create(payload: any): Observable<boolean> {
    const uri = `${this.baseUrl()}LibeyUser`;
    return this.http.post<boolean>(uri, payload);
  }

  Update(documentNumber: string, payload: any): Observable<boolean> {
    const uri = `${this.baseUrl()}LibeyUser/${encodeURIComponent(documentNumber)}`;
    return this.http.put<boolean>(uri, payload);
  }

  Delete(documentNumber: string): Observable<boolean> {
    const uri = `${this.baseUrl()}LibeyUser/${encodeURIComponent(documentNumber)}`;
    return this.http.delete<boolean>(uri);
  }

  GetDocumentTypes(): Observable<any[]> {
    const uri = `${this.baseUrl()}DocumentType`;
    return this.http.get<any[]>(uri);
  }
}
