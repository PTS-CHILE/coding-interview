import { Injectable } from '@angular/core';

interface LoaderConfig {
	show?: boolean;
	timeout?: number;
	text?: string;
}

@Injectable({
	providedIn: 'root'
})
export class LoaderHelperService {
	static showLoader = false;
	static text = '';

	constructor() { }

	toggle(config?: LoaderConfig, from?: string) {
		if (config && config.hasOwnProperty('show')) {
			LoaderHelperService.showLoader = config.show as boolean;
		}
		else {
			LoaderHelperService.showLoader = !LoaderHelperService.showLoader;
		}

		if (config && config.hasOwnProperty('text') && config.text) {
			LoaderHelperService.text = config.text;
		}

		if (config && config.timeout && LoaderHelperService.showLoader) {
			setTimeout(() => {
				LoaderHelperService.showLoader = false;
			}, config.timeout);
		}
	}
}
