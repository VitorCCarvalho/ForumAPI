import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Forum } from './../../components/forum/forum';

@Injectable({
  providedIn: 'root'
})
export class ForumService {

  private readonly API = 'https://localhost:7082/forum'

  constructor(private http: HttpClient) { }

  listar(): Observable<Forum[]> {
    return this.http.get<Forum[]>(this.API)
  }

  criar(forum: Forum): Observable<Forum> {
    return this.http.post<Forum>(this.API, forum)
  }

  editar(forum: Forum): Observable<Forum> {
    const url = `${this.API}/${forum.id}`
    return this.http.put<Forum>(url, forum)

  }

  excluir(id: number): Observable<Forum> {
    const url = `${this.API}/${id}`
    return this.http.delete<Forum>(url)
  }

  buscarPorId(id: number): Observable<Forum> {
    const url = `${this.API}/${id}`
    return this.http.get<Forum>(url)
  }

}
