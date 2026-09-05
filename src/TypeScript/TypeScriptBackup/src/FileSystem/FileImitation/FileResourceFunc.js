"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FileResourceFunc = void 0;
const EmptyObject_1 = require("../../Library/EmptyObject");
const PurePath_1 = require("../../Library/IO/PurePath");
class FileResourceFunc extends EmptyObject_1.EmptyObject {
    constructor(directory) {
        super("");
        this.directory = "";
        this.path = new PurePath_1.PurePath();
        this.types.push("FileResourceFunc");
        this.types.push("IResourceFunc");
        this.typeName = "FileResourceFunc";
        this.directory = directory;
    }
    getFillPath(path) {
        return this.path.pathCombine(this.directory, path);
    }
}
exports.FileResourceFunc = FileResourceFunc;
//# sourceMappingURL=FileResourceFunc.js.map