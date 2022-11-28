import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CreateTopicRequestModel, TopicResponse } from '../models';

@Injectable({
  providedIn: 'root',
})
export class TopicsService {
  baseUrl = `${environment.baseApiUrl}/topics`;

  constructor(private http: HttpClient) {}

  createTopic(payload: CreateTopicRequestModel): Observable<TopicResponse> {
    return this.http.post<TopicResponse>(this.baseUrl, payload);
  }

  getTopics(): Observable<TopicResponse[]> {
    return this.http.get<TopicResponse[]>(this.baseUrl);
  }
}
