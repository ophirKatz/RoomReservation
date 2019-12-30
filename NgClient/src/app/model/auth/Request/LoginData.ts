export interface LoginData {
	username: string;
	password: string;
	rememberMe: boolean;
}

export const DefaultLoginData = <LoginData> {
	username: '',
	password: '',
  rememberMe: false
};