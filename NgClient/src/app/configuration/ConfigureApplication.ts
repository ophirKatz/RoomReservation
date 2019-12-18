import { ServerConnectionConfiguration } from './ServerConnectionConfiguration';
import { IAppConfig } from './IAppConfig';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ConfigureApplication {
	static serverConnectionConfiguration: ServerConnectionConfiguration;
	constructor(private http: HttpClient) {}
	public configure() {
		const jsonFile = 'environment/config.json';
		return new Promise<void>((resolve, reject) => {
			this.http.get(jsonFile).toPromise().then((response: IAppConfig) => {
				this.setConfigs(response);
				resolve();
			}).catch((response: any) => {
				reject(`Could not load file '${jsonFile}': ${JSON.stringify(response)}`);
			});
		});
	}

	private setConfigs(appConfig: IAppConfig): void {
		ConfigureApplication.serverConnectionConfiguration =  appConfig.ServerConnectionConfiguration;
	}
}
