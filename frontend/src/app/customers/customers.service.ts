import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CustomersService {
	readonly controllerName = 'customers';

	constructor(public http: HttpClient) { }

	getCustomers(urlParams?: string): Observable<any> {
		return this.http.get(`${this.controllerName}${urlParams ? '?' + urlParams : ''}`);
	}

	getCustomerById(id: number): Observable<any> {
		return this.http.get(`${this.controllerName}/${id}`);
	}

	getCategories(): Observable<any> {
		return this.http.get(`categories`);
	}

	updateCustomer(id: number, data: any): Observable<any> {
		return this.http.put(`${this.controllerName}/${id}`, data);
	}

	createCustomer(data: any): Observable<any> {
		return this.http.post(`${this.controllerName}`, data);
	}

	deleteCustomer(id: number): Observable<any> {
		return this.http.delete(`${this.controllerName}/${id}`);
	}
}
