"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.FileResourceFuncText = void 0;
const fs_1 = __importDefault(require("fs"));
const FileResourceFunc_1 = require("./FileResourceFunc");
class FileResourceFuncText extends FileResourceFunc_1.FileResourceFunc {
    functT(s) {
        if (s.includes(".jpg"))
            return undefined;
        let path = this.getFillPath(s);
        return fs_1.default.readFileSync(path, "utf-8").replaceAll("\r\n", "\n");
    }
    constructor(directory) {
        super(directory);
        this.types.push("FileResourceFuncText");
        this.typeName = "FileResourceFuncText";
    }
}
exports.FileResourceFuncText = FileResourceFuncText;
//# sourceMappingURL=FlleResourceFuncText.js.map