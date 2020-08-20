import { Component } from '@angular/core';

import { LoaderHelperService } from './loader-helper.service';

@Component({
	selector: 'app-loader',
	templateUrl: './loader.component.html',
	styleUrls: ['./loader.component.scss']
})
export class LoaderComponent {
	loaderHelper = LoaderHelperService;

	constructor() { }

}
