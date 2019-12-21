import { UserAuthService } from './authentication/user-auth.service';
import { ServerProxyService } from './server-proxy.service';
import * as signalR from '@aspnet/signalr';

export const serverProxyProvider = {
	provide: ServerProxyService,
	useFactory: (hubConnection: signalR.HubConnection) =>
		new ServerProxyService(hubConnection),
	deps: [signalR.HubConnection]
};

export const userAuthServiceProvider = {
	provide: UserAuthService,
	useFactory: (hubConnection: signalR.HubConnection) =>
		new UserAuthService(hubConnection),
	deps: [signalR.HubConnection]
};
