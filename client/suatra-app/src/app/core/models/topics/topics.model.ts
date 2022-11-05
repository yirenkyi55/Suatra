import { CategoryResponse } from '../categories';

export interface CreateTopicModel {
  name: string;
  categoryId: string;
}

export interface TopicResponse {
  id: string;
  name: string;
  category: CategoryResponse;
}
