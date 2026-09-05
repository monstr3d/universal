"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FileImageDetectorFactory = void 0;
const FileImageDetector_1 = require("./FileImageDetector");
class FileImageDetectorFactory {
    constructor(factory) {
        this.factory = factory;
    }
    getImageDetector(object) {
        var f = this.factory.createFile(object);
        return new FileImageDetector_1.FileImageDetector(f);
    }
}
exports.FileImageDetectorFactory = FileImageDetectorFactory;
//# sourceMappingURL=FileImageDetectorFactory.js.map