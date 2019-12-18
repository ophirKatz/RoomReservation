import { Injectable } from '@angular/core';

@Injectable()
export class ServerConnectionConfiguration {
	public ServerAddress: string;
	public ServerPort: number;
	public ServerHubName: string;
}
