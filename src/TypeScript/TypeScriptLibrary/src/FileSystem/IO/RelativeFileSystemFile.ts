import { IPath } from "../../Library/IO/Interfaces/IPath";
import { FilePath } from "./FilePath";
import { FileSystemFile } from "./FileSystemFile";

export class RelativeFileSystemFile extends FileSystemFile {
    rpath: string = "";

    path: IPath = new FilePath()
    constructor(path: string) {
        super()
        this.typeName = "RelativeFileSystemFile"
        this.types.push("RelativeFileSystemFile")
        this.rpath = path;
    }
    existsFile(fileName: string): boolean {
        var f = this.path.pathCombine(this.rpath, fileName)
        return super.existsFile(f)
    }

}