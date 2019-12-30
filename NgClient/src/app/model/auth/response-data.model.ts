import { AuthResult } from '../../common/enums/auth-result';

export interface LoginResult {
	authResult: AuthResult;
	error: string;
	token: string;
}

export interface RegisterResult {
	authResult: AuthResult;
	errors: string[];
}