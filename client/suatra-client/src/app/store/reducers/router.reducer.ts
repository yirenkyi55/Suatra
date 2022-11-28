import { Params, RouterStateSnapshot } from '@angular/router';
import {
  RouterStateSerializer,
  routerReducer,
  RouterReducerState,
} from '@ngrx/router-store';
import {
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
} from '@ngrx/store';

export interface RouterStateUrl {
  url: string;
  params: Params;
  queryParams: Params;
}

export class CustomSerializer implements RouterStateSerializer<RouterStateUrl> {
  serialize(routerState: RouterStateSnapshot): RouterStateUrl {
    let route = routerState.root;

    while (route.firstChild) {
      route = route.firstChild;
    }

    const {
      url,
      root: { queryParams },
    } = routerState;

    const { params } = route;

    return { url, params, queryParams };
  }
}

export interface State {
  routerReducer: RouterReducerState<RouterStateUrl>;
}

export const reducers: ActionReducerMap<State> = {
  routerReducer: routerReducer,
};

//Selectors
export const getRouterState =
  createFeatureSelector<RouterReducerState<RouterStateUrl>>('routerReducer');

export const getUrl = createSelector(
  getRouterState,
  (routerState) => routerState?.state?.url
);

export const getQueryParams = createSelector(
  getRouterState,
  (routerState) => routerState?.state?.queryParams
);
