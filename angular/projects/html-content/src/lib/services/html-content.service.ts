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
  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/HtmlContent/sample' },
      { apiName: this.apiName }
    );
  }

  createOrUpdateContent(content: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/InsertOrUpdateCMSContent`, content);
  }

  // getContentById(id: number): Observable<any> {
  //   return this.http.get(`${this.baseUrl}/GetCMSContent/${id}`);
  // }

  getAllContent(): Observable<any> {
    return this.http.get(`https://localhost:44357/api/htmlContent/content-page`);
  }
}
