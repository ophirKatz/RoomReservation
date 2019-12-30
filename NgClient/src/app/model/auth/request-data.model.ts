export interface LoginData {
	username: string;
	password: string;
	rememberMe: boolean;
}

export interface RegisterData {
	username: string;
	password: string;
	confirmPassword: string;
}

export const DefaultLoginData = <LoginData> {
	username: '',
	password: '',
  rememberMe: false
};