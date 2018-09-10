import { Injectable } from "@angular/core";
import { ConnectionBackend, RequestOptions, Request, RequestOptionsArgs, Response, Http, Headers } from "@angular/http";
import { Observable } from "rxjs/Rx";
import { LocalizationProvider } from "../services/localizationProvider";
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import 'rxjs/Rx';

@Injectable()
export class HttpBase {

	constructor(private http: Http, private defaultOptions: RequestOptions, private localizationProvider: LocalizationProvider) { }

	private updateUrl(req: string) {
		return this.localizationProvider.baseUrl + req;
	}

	private getRequestOptionArgs(options?: RequestOptionsArgs): RequestOptionsArgs {
		if (options == null) options = new RequestOptions();
		if (options.headers == null) options.headers = new Headers();
		options.headers.append('Content-Type', 'application/json');

		return options;
	}


	get(url: string, options?: RequestOptionsArgs): Observable<any> {
		url = this.updateUrl(url);
		return this.http.get(url, this.getRequestOptionArgs(options)).map((res: Response) => res.json());
	}

	public post<T>(url: string, body: any, options?: RequestOptionsArgs): Observable<T> {
		url = this.updateUrl(url);
		return this.http.post(url, body, this.getRequestOptionArgs(options)).map((res: Response) => res.json()).catch(
			e => ErrorObservable.create(e)
		);
	}

	public put<T>(url: string, body: any, options?: RequestOptionsArgs): Observable<T> {
		url = this.updateUrl(url);
		return this.http.put(url, body, this.getRequestOptionArgs(options)).map((res: Response) => res.json()).catch(
			e => ErrorObservable.create(e)
		);
	}

	public delete<T>(url: string, options?: RequestOptionsArgs): Observable<T> {
		url = this.updateUrl(url);
		return this.http.delete(url, this.getRequestOptionArgs(options)).map((res: Response) => res.json()).catch(
			e => ErrorObservable.create(e)
		);
	}
}