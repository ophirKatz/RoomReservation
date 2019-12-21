import { AuthResult } from '../../../common/enums/auth-result';

export interface RegisterResult {
	authResult: AuthResult;
	errors: string[];
}
