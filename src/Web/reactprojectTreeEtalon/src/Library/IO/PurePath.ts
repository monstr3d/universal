import type { IPath } from "./Interfaces/IPath";
import type { IObject } from "../Interfaces/IObject";

export class PurePath implements IPath, IObject {
    pathCombine(path1: string, path2: string): string {
        let p1 = path1
        if (p1.endsWith("/") || p1.endsWith("\\")) p1 = path1.substr(0, path1.length - 1)
        let p2 = path2
        if (p2.startsWith("/") || p2.startsWith("\\")) p2 = path2.substr(1)
        return p1 + "/" + p2

    }
    getFileName(fileName: string): string {
        var n = fileName.lastIndexOf("/")
        var n1 = fileName.lastIndexOf("\\")
        if (n1 > n) n = n1
        return fileName.substr(n)
    }
    getFileExtension(fileName: string): string {
        var n = fileName.lastIndexOf(".")
        return "." + fileName.substr(n)
   }
    getFileNameWithoutExtension(fileName: string): string {
        var fn = this.getFileName(fileName)
        var n = fn.lastIndexOf(".")
        return "." + fn.substr(n)

    }
    getDirectoryName(fileName: string): string {
        var fn = this.getFileName(fileName)
        return fileName.substr(0, fileName.length - fn.length)
     }

    getName(): string {
        return this.name;
    }


    getClassName(): string {
        return this.typeName;
    }

    imlplementsType(type: string): boolean {
        return this.types.includes(type);
    }

    protected typeName: string = "PurePath";

    protected types: string[] = ["IObject", "IPath", "PurePath"];

    protected name: string = "";

}