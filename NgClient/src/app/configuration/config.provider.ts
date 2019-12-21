import { ServerConnectionConfiguration } from './server-connection-config.model';
import { IAppConfig } from './app-config.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as signalR from '@aspnet/signalr';

@Injectable()
export class ConfigurationProvider {
	public static serverConnectionConfiguration: ServerConnectionConfiguration;
	public static hubConnection: signalR.HubConnection;

	constructor(private http: HttpClient) {

	}

	public async configure(): Promise<void> {
		const jsonFile = './assets/config/config.json';
		return new Promise<void>((resolve, reject) => {
			this.http.get(jsonFile).toPromise().then(async (response: IAppConfig) => {
				await this.setConfigs(response);
				resolve();
			}).catch((response: any) => {
				reject(`Could not load file '${jsonFile}': ${JSON.stringify(response)}`);
			});
		});
	}

	private async setConfigs(appConfig: IAppConfig): Promise<void> {
		ConfigurationProvider.serverConnectionConfiguration = appConfig.ServerConnectionConfiguration;
		await this.initializeSignalRConnection(ConfigurationProvider.serverConnectionConfiguration);
	}

	private async initializeSignalRConnection(connectionConfig: ServerConnectionConfiguration): Promise<void> {
		const connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl(connectionConfig.ApiEndpoint)
      .build();

    await connection.start()
      .then(() => console.log(`SignalR Connected to endpoint: ${connectionConfig.ApiEndpoint}!`))
			.catch(err => console.error(err.toString()));
		ConfigurationProvider.hubConnection = connection;
	}
}
