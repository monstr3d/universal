"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.FilePath = void 0;
const posix_1 = __importDefault(require("path/posix"));
class FilePath {
    constructor() {
        this.typeName = "FilePath";
        this.types = ["IObject", "IObject", "IPath"];
        this.name = "";
    }
    getFileNameWithoutExtension(fileName) {
        return posix_1.default.parse(fileName).name;
    }
    getDirectoryName(fileName) {
        const fn = this.getFileName(fileName);
        return fileName.substring(0, fileName.length - fn.length - 1);
    }
    pathCombine(path1, path2) {
        return posix_1.default.join(path1, path2);
    }
    getFileName(path) {
        var parts = path.split("/");
        if (parts.length == 1) {
            parts = path.split("\\");
        }
        const fileNameWithExtension = parts[parts.length - 1];
        return fileNameWithExtension;
    }
    getFileExtension(fileName) {
        return posix_1.default.extname(fileName);
    }
    getName() {
        return this.name;
    }
    getClassName() {
        return this.typeName;
    }
    imlplementsType(type) {
        return this.types.includes(type);
    }
}
exports.FilePath = FilePath;
//# sourceMappingURL=FilePath.js.map