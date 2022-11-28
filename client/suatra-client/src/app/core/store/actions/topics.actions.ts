import { createAction, props } from '@ngrx/store';
import { CreateTopicRequestModel, TopicResponse } from '../../models';

//Create Topic
export const createTopicRequest = createAction(
  '[Topics] Create Topic Request',
  props<{ payload: CreateTopicRequestModel }>()
);
export const createTopicRequestSuccess = createAction(
  '[Topics] Create Topic Request Success',
  props<{ response: TopicResponse }>()
);
export const createTopicRequestFailure = createAction(
  '[Topics] Create Topic Request Failure',
  props<any>()
);

//Get Topics
export const getAllTopicsRequest = createAction(
  '[Topics] Get All Topics Request'
);
export const getAllTopicsRequestSuccess = createAction(
  '[Topics] Get All Topics Request Success',
  props<{ response: TopicResponse[] }>()
);
export const getAllTopicsRequestFailure = createAction(
  '[Topics] Get All Topics Request Failure',
  props<any>()
);
