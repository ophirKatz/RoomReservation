import { arrayToDictionaryMapping } from './collections-helper';

export class EnumHelpers {
	public static enumKeys(o: object): string[] {
		return Object.keys(o)
			.filter(k => typeof o[k as any] === "number");
	}
}