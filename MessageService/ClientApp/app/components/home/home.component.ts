import { Component } from '@angular/core';
import { EMailModel } from '../mailModel'
import { AlertService } from '../../services/alertService';
import { LocalizationProvider } from "../../services/localizationProvider";
import { HttpMailService } from "../../http/http.mail.service";

@Component({
	selector: 'home',
	templateUrl: './home.component.html',
	styleUrls: ['./home.component.css']

})
export class HomeComponent {
	model: EMailModel = { id: 0, name: "", mailBody: "", subject: "", url: "", recipients: [] as string[] };
	mail: string = "";
	enableList: boolean = true;
	mailList: EMailModel[] = [];

	constructor(private alertService: AlertService,
		private localizationProvider: LocalizationProvider,
		private http: HttpMailService) {

	}

	public AddMail() {
		let self = this;

		self.model.recipients.push(this.mail);
		self.mail = "";
	}

	public ClearMail() {
		let self = this;

		self.model.recipients = [];
	}

	public Show() {
		let self = this;
		self.http.get().subscribe(result => {
			self.mailList.push(...result.data);
			console.log(self.mailList);
		})
		self.enableList = !this.enableList;
	}

	public Send() {
		let self = this;
		if (self.model.url != "") {
		self.localizationProvider.baseUrl = self.model.url;
		}
		if (self.mail != "") {
			this.model.recipients.push(self.mail);
		}

		self.http.sendMessage(self.model).subscribe(result => {
			if (result) {
				this.alertService.success('Mail id = ' + result.data.id);
			}
		});
	}
}
