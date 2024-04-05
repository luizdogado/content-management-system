import { Injectable } from '@angular/core';
import { HttpClient , HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ContentPageDto } from '../models/contentPages/contentPageDto';

@Injectable({
  providedIn: 'root',
})
export class HtmlContentService {
  apiName = 'HtmlContent';

  constructor(private http: HttpClient) {}
  private baseUrl = 'https://localhost:44357'; // URL base da sua API

  createOrUpdateContent(content: ContentPageDto): Observable<any> {
    return this.http.post(`${this.baseUrl}/api/html-content/content-page`, content);
  }

  getContentById(id: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/api/html-content/content-page/${id}`);
  }

  getAllContent(skip: number | null, pageSize: number | null): Observable<any> {
    let params = new HttpParams();
    if (skip != null)
      params = params.append("SkipCount", skip);

    if (pageSize != null)
      params = params.append("MaxResult", pageSize);
    return this.http.get(`${this.baseUrl}/api/html-content/content-page`, { params });
  }
}
