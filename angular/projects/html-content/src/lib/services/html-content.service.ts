import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RestService } from '@abp/ng.core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HtmlContentService {
  apiName = 'HtmlContent';

  constructor(private restService: RestService, private http: HttpClient) {}
  private baseUrl = 'https://localhost:44357'; // URL base da sua API

  createOrUpdateContent(content: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/api/html-content/content-page`, content);
  }

  getContentById(id: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/api/html-content/content-page/${id}`);
  }

  getAllContent(): Observable<any> {
    return this.http.get(`${this.baseUrl}/api/html-content/content-page`);
  }
}
