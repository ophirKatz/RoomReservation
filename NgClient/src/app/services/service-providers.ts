import { ServerConnectionConfiguration } from "../configuration/ServerConnectionConfiguration";
import { ServerProxyService } from './server-proxy.service';

export const serverProxyProvider = {
	provide: ServerProxyService,
	useFactory: (serverConnectionConfiguration: ServerConnectionConfiguration) =>
		new ServerProxyService(serverConnectionConfiguration),
	deps: [ServerConnectionConfiguration]
};
