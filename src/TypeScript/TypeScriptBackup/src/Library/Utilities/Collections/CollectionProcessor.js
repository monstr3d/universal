"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CollectionProcessor = void 0;
class CollectionProcessor {
    arrayCopy(source, sourceIndex, destinationArray, destinationIndex, length) {
        for (let i = 0; i < length; i++) {
            destinationArray[destinationIndex + i] = source[sourceIndex + i];
        }
    }
}
exports.CollectionProcessor = CollectionProcessor;
//# sourceMappingURL=CollectionProcessor.js.map