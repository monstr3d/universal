import { IPath } from "../../Library/IO/Interfaces/IPath";
import { FilePath } from "./FilePath";
import { FileSystemDirectory } from "./FileSystemDirectory";

export class RelativeFileSystemDirectory extends FileSystemDirectory {

    rpath: string = "";

    path: IPath = new FilePath()
    constructor(path: string) {
        super()
        this.typeName = "RelativeFileSystemDirectory"
        this.types.push("RelativeFileSystemDirectory")
        this.rpath = path;
    }
    getDirectoryFiles(directory: string): string[] {
        let dir = this.path.pathCombine(this.rpath, directory)
        return super.getDirectoryFiles(dir)
    }
}