import { createEntityAdapter, EntityAdapter, EntityState } from '@ngrx/entity';
import { Action, createReducer, on } from '@ngrx/store';
import { TopicResponse, LoadingStatus } from '../../models';
import * as fromActions from '../actions/topics.actions';

export interface TopicState extends EntityState<TopicResponse> {
  status: LoadingStatus;
}

const adapter: EntityAdapter<TopicResponse> =
  createEntityAdapter<TopicResponse>();

const initialState: TopicState = adapter.getInitialState({
  status: LoadingStatus.Idle,
});

const categoryReducer = createReducer(
  initialState,

  on(
    fromActions.createTopicRequest,
    fromActions.getAllTopicsRequest,
    (state) => ({
      ...state,
      status: LoadingStatus.Loading,
    })
  ),

  on(fromActions.getAllTopicsRequestSuccess, (state, { response }) => {
    return adapter.addMany(response, {
      ...state,
      status: LoadingStatus.Success,
    });
  }),

  on(fromActions.createTopicRequestSuccess, (state, { response }) => {
    return adapter.addOne(response, {
      ...state,
      status: LoadingStatus.Success,
    });
  }),

  on(
    fromActions.createTopicRequestFailure,
    fromActions.getAllTopicsRequestFailure,
    (state) => ({
      ...state,
      status: LoadingStatus.Error,
    })
  )
);

export function reducer(state: TopicState | undefined, action: Action) {
  return categoryReducer(state, action);
}

const { selectIds, selectEntities, selectAll } = adapter.getSelectors();

export const selectTopicIds = selectIds;
export const selectTopicsEntities = selectEntities;
export const selectAllTopics = selectAll;
export const selectTopicStatus = (state: TopicState) => state.status;
