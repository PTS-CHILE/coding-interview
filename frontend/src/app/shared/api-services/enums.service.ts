import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class EnumsService {
	readonly controllerName = 'enums';

	constructor(public http: HttpClient) { }

	getEnum(enumName: string): Observable<any> {
		return this.http.get(`${this.controllerName}/${enumName}`);
	}
}
