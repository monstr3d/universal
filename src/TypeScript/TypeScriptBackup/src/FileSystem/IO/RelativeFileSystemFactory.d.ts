import { IFactory } from "../../Library/Interfaces/IFactory";
import { IFile } from "../../Library/IO/Interfaces/IFile";
import { IIODirectory } from "../../Library/IO/Interfaces/IIODirectory";
import { IPath } from "../../Library/IO/Interfaces/IPath";
import { ITextReader } from "../../Library/IO/Interfaces/ITextReader";
import { FileSystemFactory } from "./FileSystemFactory";
export declare class RelativeFileSystemFactory extends FileSystemFactory {
    rpath: string;
    path: IPath;
    constructor(path: string);
    createDirectoryFactory(object: any): IIODirectory;
    createFile(obj: any): IFile;
    getTextReader(obj: any, url: string): ITextReader;
    setFactory(factory: IFactory): void;
}
//# sourceMappingURL=RelativeFileSystemFactory.d.ts.map