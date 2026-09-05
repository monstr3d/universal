import { IPath } from '../../Library/IO/Interfaces/IPath';
import { IObject } from '../../Library/Interfaces/IObject';
export declare class FilePath implements IObject, IPath {
    protected typeName: string;
    protected types: string[];
    getFileNameWithoutExtension(fileName: string): string;
    getDirectoryName(fileName: string): string;
    pathCombine(path1: string, path2: string): string;
    getFileName(path: string): string;
    getFileExtension(fileName: string): string;
    getName(): string;
    getClassName(): string;
    imlplementsType(type: string): boolean;
    protected name: string;
}
//# sourceMappingURL=FilePath.d.ts.map