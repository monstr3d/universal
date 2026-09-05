import { IPath } from "../../Library/IO/Interfaces/IPath";
import { FileSystemDirectory } from "./FileSystemDirectory";
export declare class RelativeFileSystemDirectory extends FileSystemDirectory {
    rpath: string;
    path: IPath;
    constructor(path: string);
    getDirectoryFiles(directory: string): string[];
}
//# sourceMappingURL=RelativeFileSystemDirectory.d.ts.map