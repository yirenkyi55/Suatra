import { SubCategoryResponse } from '../sub-categories';
import { SearchQuery } from '../utils';

export interface CreateTopicRequestModel {
  name: string;
  subCategoryId: string;
}

export interface TopicResponse {
  id: string;
  name: string;
  subCategory: SubCategoryResponse;
}

export interface TopicsFilter extends SearchQuery {
  category?: string | null;
  subcategory?: string | null;
}
