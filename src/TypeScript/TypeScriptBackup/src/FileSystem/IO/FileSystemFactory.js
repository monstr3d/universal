"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FileSystemFactory = void 0;
const FilePath_1 = require("./FilePath");
const FileSystemDirectory_1 = require("./FileSystemDirectory");
const StreamReader_1 = require("./StreamReader");
const FileSystemFile_1 = require("./FileSystemFile");
class FileSystemFactory {
    constructor() {
        this.typeName = "FileSystemFactory";
        this.types = ["IObject", "ITextReaderFactory", "IFileFactory", "IIODirectoryFactory",
            "IPathFactory", "FileSystemFactory"];
        this.name = "";
    }
    createPath(obj) {
        return new FilePath_1.FilePath();
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
    createDirectoryFactory(object) {
        return new FileSystemDirectory_1.FileSystemDirectory();
    }
    createFile(obj) {
        return new FileSystemFile_1.FileSystemFile();
    }
    getTextReader(obj, url) {
        return new StreamReader_1.StreamReader(url);
    }
    setFactory(factory) {
        let ff = new FileSystemFactory();
        factory.addFactory(ff, "ITextReaderFactory");
        factory.addFactory(ff, "IFileFactory");
        factory.addFactory(ff, "IIODirectoryFactory");
        factory.addFactory(ff, "IPathFactory");
    }
}
exports.FileSystemFactory = FileSystemFactory;
//# sourceMappingURL=FileSystemFactory.js.map