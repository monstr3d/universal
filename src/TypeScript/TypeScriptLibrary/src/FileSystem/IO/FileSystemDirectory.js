"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.FileSystemDirectory = void 0;
const fs_1 = __importDefault(require("fs"));
const posix_1 = __importDefault(require("path/posix"));
class FileSystemDirectory {
    getName() {
        return this.name;
    }
    getClassName() {
        return this.typeName;
    }
    imlplementsType(type) {
        return this.types.includes(type);
    }
    typeName = "FileSystemDirectory";
    types = ["IObject", "IIODirectory", "FileSystemDirectory"];
    name = "";
    getDirectoryFiles(directory) {
        this.files = [];
        var files = fs_1.default.readdirSync(directory);
        for (const f of files) {
            this.files.push(posix_1.default.join(directory, f));
        }
        return this.files;
    }
    files = [];
}
exports.FileSystemDirectory = FileSystemDirectory;
