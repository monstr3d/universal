export class CollectionProcessor {

    arrayCopy<T>(source: T[], sourceIndex: number, destinationArray: T[], destinationIndex: number, length: number): void {
        for (let i = 0; i < length; i++) {
            destinationArray[destinationIndex + i] = source[sourceIndex + i];
        }
    }

}

