import { IPath } from "../../Library/IO/Interfaces/IPath";
import { FileSystemFile } from "./FileSystemFile";
export declare class RelativeFileSystemFile extends FileSystemFile {
    rpath: string;
    path: IPath;
    constructor(path: string);
    existsFile(fileName: string): boolean;
}
//# sourceMappingURL=RelativeFileSystemFile.d.ts.map