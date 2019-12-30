import { AuthResult } from '../../common/enums/auth-result';
import { HubMethods } from '../../model/hub-methods';
import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { RegisterResult, LoginResult } from 'src/app/model/auth/response-data.model';
import { RegisterData, LoginData } from 'src/app/model/auth/request-data.model';

@Injectable({
  providedIn: 'root'
})
export class UserAuthService {

  constructor(private hubConnection: signalR.HubConnection) {}

  public async register(registerData: RegisterData): Promise<RegisterResult> {
    return await this.hubConnection.invoke(HubMethods.register, registerData)
      .then((registerResult: RegisterResult) => registerResult)
      .catch(error => {
        console.log(`Error with registering user ${registerData.username}: ${error}`);
        return null;
      });
  }

  public async login(loginData: LoginData): Promise<LoginResult> {
    return await this.hubConnection.invoke(HubMethods.login, loginData)
      .then((loginResult: LoginResult) => {
        if (loginResult == null || loginResult.authResult !== AuthResult.Success) {
          return loginResult;
        }
        // TODO : authenticate current user
        // TODO : set token as local storage item

        return loginResult;
      }).catch(error => {
        console.log(`Error with logging in user ${loginData.username}: ${error}`);
        return null;
      });
  }

  public logout() {
    // TODO : remove token as local storage item
    // TODO : delete user authentication
  }
}
