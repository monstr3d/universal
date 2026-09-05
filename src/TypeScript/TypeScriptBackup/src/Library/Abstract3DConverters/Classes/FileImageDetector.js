"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FileImageDetector = void 0;
class FileImageDetector {
    constructor(fileDetector) {
        this.fileDetector = fileDetector;
    }
    detectImage(file) {
        return this.fileDetector.existsFile(file);
    }
}
exports.FileImageDetector = FileImageDetector;
//# sourceMappingURL=FileImageDetector.js.map