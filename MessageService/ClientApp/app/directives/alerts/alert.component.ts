import { Component, OnInit } from '@angular/core';
import { trigger, style, transition, animate, state, query, stagger, keyframes } from '@angular/animations';

import { Alert, AlertType } from '../alerts/alert.model';
import { AlertService } from '../../services/alertService';

@Component({
	selector: 'alert',
	templateUrl: 'alert.component.html',
	animations: [

		trigger('listAnimation', [
			transition('* => *', [

				query(':enter', style({ opacity: 0 }), { optional: true }),

				query(':enter', stagger('300ms', [
					animate('1s ease-out', keyframes([
						style({ opacity: 1, transform: 'translateY(0)', offset: 1.0 }),
					]))]), { optional: true })
				,
				query(':leave', stagger('300ms', [
					animate('.6s ease-out', keyframes([
						style({ opacity: 0, transform: 'translateY(-75%)', offset: 1.0 }),
					]))]), { optional: true })
			])
		])

	]
})

export class AlertComponent {
	alerts: Alert[] = [];
	constructor(private alertService: AlertService) { }

	ngOnInit() {
		this.alertService.getAlert().subscribe((alert: Alert) => {
			if (!alert) {
				this.alerts = [];
				return;
			}
			if (this.alerts.length > 0) {
				this.alerts = [];
			}
			this.alerts.push(alert);
			setTimeout(() => this.removeAlert(alert), 2000);
		});
	}

	removeAlert(alert: Alert) {
		this.alerts = this.alerts.filter(x => x !== alert);
	}

	cssClass(alert: Alert) {

		if (!alert) {
			return;
		}
		switch (alert.type) {
			case AlertType.Success:
				return 'alert alert-success';
			case AlertType.Error:
				return 'alert alert-danger';
			case AlertType.Info:
				return 'alert alert-info';
			case AlertType.Warning:
				return 'alert alert-warning';
		}
	}
}