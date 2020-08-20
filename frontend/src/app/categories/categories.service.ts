import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CategoriesService {
	readonly controllerName = 'categories';

	constructor(private http: HttpClient) { }

	getCategories(urlParams?: string): Observable<any> {
		return this.http.get(`${this.controllerName}${urlParams ? '?' + urlParams : ''}`);
	}

	getCategoryById(id: number): Observable<any> {
		return this.http.get(`${this.controllerName}/${id}`);
	}

	updateCategory(id: number, data: any): Observable<any> {
		return this.http.put(`${this.controllerName}/${id}`, data);
	}

	createCategory(data: any): Observable<any> {
		return this.http.post(`${this.controllerName}`, data);
	}

	deleteCategory(id: number): Observable<any> {
		return this.http.delete(`${this.controllerName}/${id}`);
	}
}
