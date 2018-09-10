//module
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


//comp
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { AlertComponent } from '../app/directives/alerts/alert.component';

//service
import { AlertService } from './services/alertService';
import { LocalizationProvider } from './services/localizationProvider';
import { HttpBase } from './http/http.base'
import { HttpMailService } from "./http/http.mail.service";

@NgModule({
	declarations: [
		AppComponent,
		NavMenuComponent,
		AlertComponent,
		HomeComponent
	],
	imports: [
		CommonModule,
		HttpModule,
		FormsModule,
		BrowserAnimationsModule,
		RouterModule.forRoot([
			{ path: '', redirectTo: 'home', pathMatch: 'full' },
			{ path: 'home', component: HomeComponent },
			{ path: '**', redirectTo: 'home' }
		])
	], providers: [
		AlertService,
		LocalizationProvider,
		HttpBase,
		HttpMailService
	]
})
export class AppModuleShared {
}
