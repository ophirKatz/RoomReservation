import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { ServerConnectionConfiguration } from '../configuration/ServerConnectionConfiguration';

@Injectable({
  providedIn: 'root'
})
export class ServerProxyService {
  //#region Constructor

  constructor(private serverConnectionConfiguration: ServerConnectionConfiguration) {
    const serverApiUrl = `http://${serverConnectionConfiguration.ServerAddress}:
      ${serverConnectionConfiguration.ServerPort}/${serverConnectionConfiguration.ServerHubName}`;
    const connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl(serverApiUrl)
      .build();

    connection.start()
      .then(() => console.log('SignalR Connected!'))
      .catch(err => console.error(err.toString()));
  }

  //#endregion
}
