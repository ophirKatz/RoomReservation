import { ServerConnectionConfiguration } from './server-connection-config.model';
import { Injectable } from '@angular/core';

export interface IAppConfig {
	ServerConnectionConfiguration: ServerConnectionConfiguration;
}

@Injectable()
export class AppConfig implements IAppConfig {
	public ServerConnectionConfiguration: ServerConnectionConfiguration;
}
