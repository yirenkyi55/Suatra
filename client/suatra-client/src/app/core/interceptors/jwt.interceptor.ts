import { environment } from 'src/environments/environment';
import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Observable } from 'rxjs';

export class JwtInterceptor implements HttpInterceptor {
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const authState = localStorage.getItem('authState');

    if (authState) {
      const token = JSON.parse(authState)?.auth?.currentUser?.accessToken;

      if (req.url.search(environment.baseApiUrl) !== -1) {
        if (token) {
          req = req.clone({
            setHeaders: {
              Authorization: `Bearer ${token}`,
            },
            withCredentials: true,
          });
        }
      }
    }

    return next.handle(req);
  }
}
