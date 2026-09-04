import fs from 'fs';
import path from 'path/posix';
import { IIODirectory } from '../../Library/IO/Interfaces/IIODirectory';
import { IObject } from '../../Library/Interfaces/IObject';



export class FileSystemDirectory implements IObject, IIODirectory {

    getName(): string {
        return this.name;
    }


    getClassName(): string {
        return this.typeName;
    }

    imlplementsType(type: string): boolean {
        return this.types.includes(type)
    }

    protected typeName: string = "FileSystemDirectory";

    protected types: string[] = ["IObject", "IIODirectory", "FileSystemDirectory"];

    protected name: string = "";


    getDirectoryFiles(directory: string): string[] {
        this.files = []
        var files = fs.readdirSync(directory)
        for (const f of files) {
            this.files.push(path.join(directory, f))
        }
        return this.files
    }

    protected files: string[] = []



}