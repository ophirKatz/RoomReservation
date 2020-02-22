export function arrayToDictionary<TValue>(array: Array<{key: string, value: TValue}>): { [key: string]: TValue } {
	const normalizedObject: { [key: string]: TValue } = {};

	for (let item of array) {
		normalizedObject[item.key] = item.value;
	}

	return normalizedObject;
}

export function arrayToDictionaryMapping<T, TValue>(array: Array<T>,
	keyMapper: (item: T) => string,
	valueMapper: (item: T) => TValue): { [key: string]: TValue } {
	let itemMapper: (item: T) => {key: string, value: TValue} = item => {
		return {key: keyMapper(item), value: valueMapper(item)};
	};
	let newArray = array.map(itemMapper);
	return arrayToDictionary<TValue>(newArray);
}