"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RelativeFileSystemDirectory = void 0;
const FilePath_1 = require("./FilePath");
const FileSystemDirectory_1 = require("./FileSystemDirectory");
class RelativeFileSystemDirectory extends FileSystemDirectory_1.FileSystemDirectory {
    constructor(path) {
        super();
        this.rpath = "";
        this.path = new FilePath_1.FilePath();
        this.typeName = "RelativeFileSystemDirectory";
        this.types.push("RelativeFileSystemDirectory");
        this.rpath = path;
    }
    getDirectoryFiles(directory) {
        let dir = this.path.pathCombine(this.rpath, directory);
        return super.getDirectoryFiles(dir);
    }
}
exports.RelativeFileSystemDirectory = RelativeFileSystemDirectory;
//# sourceMappingURL=RelativeFileSystemDirectory.js.map