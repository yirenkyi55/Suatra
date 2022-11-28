import { catchError, map, of, switchMap } from 'rxjs';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { TopicsService } from '../../services';
import * as fromTopicActions from '../actions/topics.actions';

@Injectable()
export class TopicEffects {
  constructor(private actions$: Actions, private topicService: TopicsService) {}

  getTopics$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromTopicActions.getAllTopicsRequest),
      switchMap(() =>
        this.topicService.getTopics().pipe(
          map((response) =>
            fromTopicActions.getAllTopicsRequestSuccess({
              response,
            })
          ),
          catchError((error) =>
            of(fromTopicActions.getAllTopicsRequestFailure(error))
          )
        )
      )
    )
  );

  createTopic$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromTopicActions.createTopicRequest),
      switchMap(({ payload }) =>
        this.topicService.createTopic(payload).pipe(
          map((response) =>
            fromTopicActions.createTopicRequestSuccess({
              response,
            })
          ),
          catchError((error) =>
            of(fromTopicActions.createTopicRequestFailure(error))
          )
        )
      )
    )
  );
}
