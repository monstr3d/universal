import { IIODirectory } from '../../Library/IO/Interfaces/IIODirectory';
import { IObject } from '../../Library/Interfaces/IObject';
export declare class FileSystemDirectory implements IObject, IIODirectory {
    getName(): string;
    getClassName(): string;
    imlplementsType(type: string): boolean;
    protected typeName: string;
    protected types: string[];
    protected name: string;
    getDirectoryFiles(directory: string): string[];
    protected files: string[];
}
//# sourceMappingURL=FileSystemDirectory.d.ts.map