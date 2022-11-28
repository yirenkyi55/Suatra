import { CategoryResponse } from '../categories';
import { SearchQuery } from '../utils';

export interface CreateSubCategoryModel {
  categoryId: string;
  name: string;
}

export interface SubCategoryResponse {
  id: string;
  name: string;
  category: CategoryResponse;
}

export interface SubCategoryFilter extends SearchQuery {
  category?: string | null;
}
