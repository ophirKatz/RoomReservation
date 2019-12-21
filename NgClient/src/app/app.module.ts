import { HttpClientModule } from '@angular/common/http'; 
import { ConfigurationProvider } from './configuration/config.provider';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';

// Components
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { HomeComponent } from './pages/home/home.component';

// Services & Service Providers
import { serverProxyProvider, userAuthServiceProvider } from './services/service-providers';
import { HubConnection } from '@aspnet/signalr';

// Configuration
export function initializeApp(appConfigurator: ConfigurationProvider) {
  return () => appConfigurator.configure();
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    ConfigurationProvider,
    {
      provide: APP_INITIALIZER,
      useFactory: initializeApp,
      deps: [ConfigurationProvider],
      multi: true
    },
    {
      provide: HubConnection,
      useFactory: () => ConfigurationProvider.hubConnection
    },
    serverProxyProvider,
    userAuthServiceProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
