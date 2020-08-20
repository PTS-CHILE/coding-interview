import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { httpInterceptorProviders } from './http-interceptors/http-interceptors';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoaderComponent } from './loader/loader.component';
import { ProductsComponent } from './products/products.component';
import { ProductsService } from './products/products.service';

@NgModule({
	declarations: [
		AppComponent,
		HomeComponent,
		LoaderComponent,
		ProductsComponent
	],
	imports: [
		BrowserModule,
		HttpClientModule,
		AppRoutingModule,
		BrowserAnimationsModule
	],
	exports: [
		LoaderComponent
	],
	providers: [
		httpInterceptorProviders,
		ProductsService
	],
	bootstrap: [AppComponent]
})
export class AppModule { }
