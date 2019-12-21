import { LoginData } from './../../model/auth/Request/LoginData';
import { LoginResult } from './../../model/auth/Response/LoginResult';
import { UserAuthService } from './../../services/authentication/user-auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private userAuthService: UserAuthService) { }

  ngOnInit() {
    const loginData: LoginData = <LoginData> {
      username: 'ofirkatz',
      password: 'Aa123456',
      rememberMe: true
    };
    this.userAuthService.login(loginData)
      .then(res => {
        console.log('received data from authService: ' + res);
        this.userResult = res;
      }).catch(err => console.log(`error: ${err}`));
  }

  private userResult: LoginResult;
}
