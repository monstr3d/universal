"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RelativeFileSystemFile = void 0;
const FilePath_1 = require("./FilePath");
const FileSystemFile_1 = require("./FileSystemFile");
class RelativeFileSystemFile extends FileSystemFile_1.FileSystemFile {
    constructor(path) {
        super();
        this.rpath = "";
        this.path = new FilePath_1.FilePath();
        this.typeName = "RelativeFileSystemFile";
        this.types.push("RelativeFileSystemFile");
        this.rpath = path;
    }
    existsFile(fileName) {
        var f = this.path.pathCombine(this.rpath, fileName);
        return super.existsFile(f);
    }
}
exports.RelativeFileSystemFile = RelativeFileSystemFile;
//# sourceMappingURL=RelativeFileSystemFile.js.map