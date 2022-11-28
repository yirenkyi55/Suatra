import { createSelector } from '@ngrx/store';
import * as fromTopics from '../reducers/topics.reducers';
import * as fromReducer from '../reducers';
import { TopicResponse, TopicsFilter } from '../../models';

export const selectTopicState = createSelector(
  fromReducer.selectAppState,
  (state) => state.topics
);

export const selectTopicsEntities = createSelector(
  selectTopicState,
  fromTopics.selectTopicsEntities
);

export const selectTopics = createSelector(
  selectTopicState,
  fromTopics.selectAllTopics
);

export const selectTopicStatus = createSelector(
  selectTopicState,
  fromTopics.selectTopicStatus
);

export const selectSubTopicsByFilterAndSearching = (filters: TopicsFilter) =>
  createSelector(selectTopics, (topics) => {
    let itemsToReturn: TopicResponse[] = [...topics];

    if (filters.category) {
      itemsToReturn = itemsToReturn.filter(
        (item) =>
          item.subCategory.category.id.toLocaleLowerCase() ===
          filters.category?.toLocaleLowerCase()
      );
    }

    if (filters.subcategory) {
      itemsToReturn = itemsToReturn.filter(
        (item) =>
          item.subCategory.id.toLocaleLowerCase() ===
          filters.subcategory?.toLocaleLowerCase()
      );
    }

    if (filters.query) {
      itemsToReturn = itemsToReturn.filter(
        (item) =>
          item.name
            .toLocaleLowerCase()
            .includes(filters.query!.toLocaleLowerCase()) ||
          item.subCategory.name
            .toLocaleLowerCase()
            .includes(filters.query!.toLocaleLowerCase()) ||
          item.subCategory.category.name
            .toLocaleLowerCase()
            .includes(filters.query!.toLocaleLowerCase())
      );
    }
    return itemsToReturn;
  });
