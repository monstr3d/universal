import { IFactory } from "../../Library/Interfaces/IFactory";
import { IObject } from "../../Library/Interfaces/IObject";
import { IFile } from "../../Library/IO/Interfaces/IFile";
import { IFileFactory } from "../../Library/IO/Interfaces/IFileFactory";
import { IIODirectory } from "../../Library/IO/Interfaces/IIODirectory";
import { IIODirectoryFactory } from "../../Library/IO/Interfaces/IIODirectoryFactory";
import { IPath } from "../../Library/IO/Interfaces/IPath";
import { IPathFactory } from "../../Library/IO/Interfaces/IPathFactory";
import { ITextReader } from "../../Library/IO/Interfaces/ITextReader";
import { ITextReaderFactory } from "../../Library/IO/Interfaces/ITextReaderFactory";
export declare class FileSystemFactory implements IObject, ITextReaderFactory, IFileFactory, IIODirectoryFactory, IPathFactory {
    createPath(obj: any): IPath;
    getName(): string;
    getClassName(): string;
    imlplementsType(type: string): boolean;
    protected typeName: string;
    protected types: string[];
    protected name: string;
    createDirectoryFactory(object: any): IIODirectory;
    createFile(obj: any): IFile;
    getTextReader(obj: any, url: string): ITextReader;
    setFactory(factory: IFactory): void;
}
//# sourceMappingURL=FileSystemFactory.d.ts.map