import { Injectable } from '@angular/core';

export interface IAppConfig {
	ServerConnectionConfiguration: {
		ServerAddress: string,
		ServerPort: number,
		ServerHubName: string
	};
}

@Injectable()
export class AppConfig implements IAppConfig {
	public ServerConnectionConfiguration: {
		ServerAddress: string;
		ServerPort: number;
		ServerHubName: string;
	};
}
