// Modules & Tokens
import { HttpClientModule } from '@angular/common/http'; 
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material';

// Components
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { HomeComponent } from './pages/home/home.component';
import { IndexComponent } from './pages/index/index.component';
import { NavbarComponent } from './pages/home/navbar/navbar.component';
import { MenuComponent } from './pages/home/menu/menu.component';
import { RoomsComponent } from './components/rooms/rooms.component';
import { ReservationsComponent } from './components/reservations/reservations.component';
import { ReservationActionComponent } from './components/reservation-action/reservation-action.component';

// Services & Providers
import { ConfigurationProvider } from './configuration/config.provider';
import { HubConnection } from '@aspnet/signalr';
import { RoomViewComponent } from './components/rooms/room-view/room-view.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    IndexComponent,
    NavbarComponent,
    MenuComponent,
    RoomsComponent,
    ReservationsComponent,
    ReservationActionComponent,
    RoomViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NoopAnimationsModule,
    MatDatepickerModule,
    MatMomentDateModule,
    MatFormFieldModule,
    MatSelectModule
  ],
  providers: [
    ConfigurationProvider,
    {
      provide: APP_INITIALIZER,
      useFactory: ConfigurationProvider.appConfigurator,
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
export class AppModule {}