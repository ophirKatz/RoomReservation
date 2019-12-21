import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';

@Injectable({
	providedIn: 'root'
})
export class ServerProxyService {
	//#region Constructor

	constructor(private hubConnection: signalR.HubConnection) {}

	//#endregion

	//#region Server Requests



	//#endregion

	//#region Listeners

	//#endregion
}
