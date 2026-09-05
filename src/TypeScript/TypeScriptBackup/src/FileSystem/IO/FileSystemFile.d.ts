import { IFile } from "../../Library/IO/Interfaces/IFile";
import { IObject } from '../../Library/Interfaces/IObject';
export declare class FileSystemFile implements IObject, IFile {
    existsFile(fileName: string): boolean;
    getName(): string;
    getClassName(): string;
    imlplementsType(type: string): boolean;
    protected typeName: string;
    protected types: string[];
    protected name: string;
}
//# sourceMappingURL=FileSystemFile.d.ts.map