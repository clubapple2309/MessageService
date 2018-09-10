import { Observable } from 'rxjs/Rx';
import { HttpBase } from './http.base';
import { Injectable } from "@angular/core";
import { EMailModel } from '../components/mailModel'

@Injectable()
export class HttpMailService {


	constructor(private httpBase: HttpBase) {

	}
	get(): Observable<any> {
		return this.httpBase.get('/Mail');
	}

	sendMessage(mail:EMailModel): Observable<any> {
		return this.httpBase.post('/Mail', mail);
	}
}