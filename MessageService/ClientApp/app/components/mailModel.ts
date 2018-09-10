export class EMailModel {
	constructor() {
	}
	public id: number;
	public name: string;
	public url: string;
	public subject: string;
	public mailBody: string;
	public recipients: Array<string>;
	public isSent?: boolean;
}
