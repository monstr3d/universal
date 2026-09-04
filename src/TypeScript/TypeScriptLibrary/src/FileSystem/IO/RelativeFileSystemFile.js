"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RelativeFileSystemFile = void 0;
const FilePath_1 = require("./FilePath");
const FileSystemFile_1 = require("./FileSystemFile");
class RelativeFileSystemFile extends FileSystemFile_1.FileSystemFile {
    rpath = "";
    path = new FilePath_1.FilePath();
    constructor(path) {
        super();
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
