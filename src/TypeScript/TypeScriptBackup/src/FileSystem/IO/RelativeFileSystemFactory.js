"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RelativeFileSystemFactory = void 0;
const FilePath_1 = require("./FilePath");
const FileSystemFactory_1 = require("./FileSystemFactory");
const RelativeFileSystemDirectory_1 = require("./RelativeFileSystemDirectory");
const RelativeFileSystemFile_1 = require("./RelativeFileSystemFile");
const StreamReader_1 = require("./StreamReader");
class RelativeFileSystemFactory extends FileSystemFactory_1.FileSystemFactory {
    constructor(path) {
        super();
        this.rpath = "";
        this.path = new FilePath_1.FilePath();
        this.typeName = "RelativeFileSystemFactory";
        this.types.push("RelativeFileSystemFactory");
        this.rpath = path;
    }
    createDirectoryFactory(object) {
        return new RelativeFileSystemDirectory_1.RelativeFileSystemDirectory(this.rpath);
    }
    createFile(obj) {
        return new RelativeFileSystemFile_1.RelativeFileSystemFile(this.rpath);
    }
    getTextReader(obj, url) {
        let d = this.path.pathCombine(this.rpath, url);
        return new StreamReader_1.StreamReader(d);
    }
    setFactory(factory) {
        factory.addFactory(this, "ITextReaderFactory");
        factory.addFactory(this, "IFileFactory");
        factory.addFactory(this, "IIODirectoryFactory");
        factory.addFactory(this, "IPathFactory");
    }
}
exports.RelativeFileSystemFactory = RelativeFileSystemFactory;
//# sourceMappingURL=RelativeFileSystemFactory.js.map