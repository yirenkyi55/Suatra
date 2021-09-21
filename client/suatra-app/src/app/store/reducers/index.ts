import { Params, RouterStateSnapshot } from '@angular/router';
import {
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
} from '@ngrx/store';
import * as fromRouterStore from '@ngrx/router-store';

export interface RouterStateUrl {
  url: string;
  params: Params;
  queryParams: Params;
}

export interface State {
  routerReducer: fromRouterStore.RouterReducerState<RouterStateUrl>;
}

export const reducers: ActionReducerMap<State> = {
  routerReducer: fromRouterStore.routerReducer,
};

export class CustomSerializer
  implements fromRouterStore.RouterStateSerializer<RouterStateUrl>
{
  serialize(routerState: RouterStateSnapshot): RouterStateUrl {
    const { url } = routerState;
    const { queryParams } = routerState.root;

    let route = routerState.root;

    while (route.firstChild) {
      route = route.firstChild;
    }

    const params = route.params;

    return { url, params, queryParams };
  }
}

// Defining Selectors
export const getRouterState =
  createFeatureSelector<fromRouterStore.RouterReducerState<RouterStateUrl>>(
    'routerReducer'
  );

export const getUrl = createSelector(
  getRouterState,
  (routerState) => routerState?.state?.url
);
