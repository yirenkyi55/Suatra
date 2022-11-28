export interface CreateCategoryModel {
  name: string;
}

export interface CategoryResponse extends CreateCategoryModel {
  id: string;
}
