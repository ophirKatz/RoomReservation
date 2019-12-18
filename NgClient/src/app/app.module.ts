import { ServerConnectionConfiguration } from './configuration/ServerConnectionConfiguration';
import { ServerProxyService } from './services/server-proxy.service';
import { ConfigureApplication } from './configuration/ConfigureApplication';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';

// Components
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { HomeComponent } from './pages/home/home.component';

// Services & Service Providers
import { serverProxyProvider } from './services/service-providers';

// Configuration
export function initializeApp(appConfigurator: ConfigureApplication) {
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
    AppRoutingModule
  ],
  providers: [
    { provide: APP_INITIALIZER,
      useFactory: initializeApp,
      deps: [ConfigureApplication], multi: true },
    serverProxyProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
