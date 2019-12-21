import { AuthResult } from '../../../common/enums/auth-result';

export interface LoginResult {
	authResult: AuthResult;
	error: string;
	token: string;
}
