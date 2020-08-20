import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';

@NgModule({
	declarations: [
		HeaderComponent
	],
	imports: [
		FormsModule,
		CommonModule,
		ReactiveFormsModule,
	],
	exports: [
		FormsModule,
		CommonModule,
		HeaderComponent,
		ReactiveFormsModule
	]
})
export class SharedModule { }
