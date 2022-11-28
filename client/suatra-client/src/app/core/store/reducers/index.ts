import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';
import * as fromCategories from '../reducers/categories.reducers';
import * as fromUtils from '../reducers/utils.reducers';
import * as fromSubCategory from '../reducers/sub-categories.reducers';
import * as fromTopics from './topics.reducers';

export interface AppState {
  categories: fromCategories.CategoryState;
  utils: fromUtils.UtilState;
  subCategories: fromSubCategory.SubCategoryState;
  topics: fromTopics.TopicState;
}

export const reducers: ActionReducerMap<AppState> = {
  categories: fromCategories.reducer,
  utils: fromUtils.reducer,
  subCategories: fromSubCategory.reducer,
  topics: fromTopics.reducer,
};

export const selectAppState = createFeatureSelector<AppState>('appState');
