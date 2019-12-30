import { LoginData, DefaultLoginData } from '../../model/auth/Request/LoginData';
import { LoginResult } from '../../model/auth/Response/LoginResult';
import { UserAuthService } from '../../services/authentication/user-auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public constructor(private formBuilder: FormBuilder,
    private userAuthService: UserAuthService) {
    this.loginForm = this.formBuilder.group(DefaultLoginData);
  }

  public ngOnInit() {
  }

  private onSubmit(formData: LoginData): void {
    // Process checkout data here
    const loginData: LoginData = <LoginData> {
      username: formData.username,
      password: formData.password,
      rememberMe: formData.rememberMe
    };
    console.log('loginData', loginData);
    this.userAuthService.login(loginData);
    this.loginForm.reset();
  }

  private loginForm: FormGroup;
}
