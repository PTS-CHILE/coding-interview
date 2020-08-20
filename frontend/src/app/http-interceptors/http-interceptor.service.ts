import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import {
	HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpHeaders
} from '@angular/common/http';

import { environment } from 'src/environments/environment';

@Injectable({
	providedIn: 'root'
})
export class HttpInterceptorService implements HttpInterceptor {

	constructor() { }

	intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		if (req instanceof HttpRequest) {
			const headers = new HttpHeaders();
			headers.append('Access-Control-Allow-Headers', 'Content-Type');
			headers.append('Access-Control-Allow-Origin', '*');
			headers.append('Content-Type', 'application/json');
			const urlApi = req.clone({
				url: this.createUrl(req.url),
				headers
			});
			return next.handle(urlApi);
		} else {
			return next.handle(req);
		}
	}

	private createUrl(url: string): string {
		return environment.host + url;
	}
}

