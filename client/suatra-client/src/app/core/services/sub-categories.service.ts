import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CreateSubCategoryModel, SubCategoryResponse } from '../models';

@Injectable({
  providedIn: 'root',
})
export class SubCategoriesService {
  baseUrl = `${environment.baseApiUrl}/subcategories`;

  constructor(private http: HttpClient) {}

  createSubCategory(
    payload: CreateSubCategoryModel
  ): Observable<SubCategoryResponse> {
    return this.http.post<SubCategoryResponse>(this.baseUrl, payload);
  }

  getSubCategories(): Observable<SubCategoryResponse[]> {
    return this.http.get<SubCategoryResponse[]>(this.baseUrl);
  }
}
