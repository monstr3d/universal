"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PurePath = void 0;
class PurePath {
    pathCombine(path1, path2) {
        let p1 = path1;
        if (p1.endsWith("/") || p1.endsWith("\\"))
            p1 = path1.substr(0, path1.length - 1);
        let p2 = path2;
        if (p2.startsWith("/") || p2.startsWith("\\"))
            p2 = path2.substr(1);
        return p1 + "/" + p2;
    }
    getFileName(fileName) {
        var n = fileName.lastIndexOf("/");
        var n1 = fileName.lastIndexOf("\\");
        if (n1 > n)
            n = n1;
        return fileName.substr(n);
    }
    getFileExtension(fileName) {
        var n = fileName.lastIndexOf(".");
        return "." + fileName.substr(n);
    }
    getFileNameWithoutExtension(fileName) {
        var fn = this.getFileName(fileName);
        var n = fn.lastIndexOf(".");
        return "." + fn.substr(n);
    }
    getDirectoryName(fileName) {
        var fn = this.getFileName(fileName);
        return fileName.substr(0, fileName.length - fn.length);
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
    typeName = "PurePath";
    types = ["IObject", "IPath", "PurePath"];
    name = "";
}
exports.PurePath = PurePath;
