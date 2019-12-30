// Modules
import { HttpClientModule } from '@angular/common/http'; 
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// Components
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { HomeComponent } from './pages/home/home.component';

// Services & Service Providers
import { ConfigurationProvider } from './configuration/config.provider';
import { HubConnection } from '@aspnet/signalr';
import { IndexComponent } from './pages/index/index.component';
import { NavbarComponent } from './pages/home/navbar/navbar.component';
import { MenuComponent } from './pages/home/menu/menu.component';
import { RoomsComponent } from './components/rooms/rooms.component';

// Configuration
export function initializeApp(appConfigurator: ConfigurationProvider) {
  return () => appConfigurator.configure();
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    IndexComponent,
    NavbarComponent,
    MenuComponent,
    RoomsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
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
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
