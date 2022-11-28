import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CategoryResponse, CreateCategoryModel } from '../models';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  baseUrl = `${environment.baseApiUrl}/categories`;

  constructor(private http: HttpClient) {}

  createCategory(
    requestModel: CreateCategoryModel
  ): Observable<CategoryResponse> {
    return this.http.post<CategoryResponse>(this.baseUrl, requestModel);
  }

  getCategories(): Observable<CategoryResponse[]> {
    return this.http.get<CategoryResponse[]>(this.baseUrl);
  }
}
