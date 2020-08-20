import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class ProductsService {
	readonly controllerName = 'externalproducts';

	constructor(public http: HttpClient) { }

	getProducts(urlParams?: string): Observable<any> {
		return this.http.get(`${this.controllerName}${urlParams ? '?' + urlParams : ''}`);
	}
}
