import path from 'path/posix';
import { IPath } from '../../Library/IO/Interfaces/IPath';
import { IObject } from '../../Library/Interfaces/IObject';

export class FilePath implements IObject, IPath
{
    protected typeName: string = "FilePath";

    protected types: string[] = ["IObject", "IObject", "IPath"];

    getFileNameWithoutExtension(fileName: string): string {
        return path.parse(fileName).name
    }

    getDirectoryName(fileName: string): string {
        const fn = this.getFileName(fileName)
        return fileName.substring(0, fileName.length - fn.length - 1)
    }

    pathCombine(path1: string, path2: string): string {
        return path.join(path1, path2)
    }

    getFileName(path: string): string {
        var parts = path.split("/");
        if (parts.length == 1) {
            parts = path.split("\\")
        }
        const fileNameWithExtension = parts[parts.length - 1];

        return fileNameWithExtension;
    }
    getFileExtension(fileName: string): string {
        return path.extname(fileName)
    }

    getName(): string {
        return this.name;
    }


    getClassName(): string {
        return this.typeName;
    }

    imlplementsType(type: string): boolean {
        return this.types.includes(type)
    }

 
    protected name: string = "";

}