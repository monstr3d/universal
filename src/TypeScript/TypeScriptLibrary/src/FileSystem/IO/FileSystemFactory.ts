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
import { FilePath } from "./FilePath";
import { FileSystemDirectory } from "./FileSystemDirectory";
import { StreamReader } from "./StreamReader";
import { FileSystemFile } from './FileSystemFile';


export class FileSystemFactory implements IObject, ITextReaderFactory, IFileFactory, IIODirectoryFactory,
    IPathFactory {
    createPath(obj: any): IPath {
        return new FilePath()
    }

    getName(): string {
        return this.name;
    }


    getClassName(): string {
        return this.typeName;
    }

    imlplementsType(type: string): boolean {
        return this.types.includes(type);
    }

    protected typeName: string = "FileSystemFactory";

    protected types: string[] = ["IObject", "ITextReaderFactory", "IFileFactory", "IIODirectoryFactory",
        "IPathFactory", "FileSystemFactory"];

    protected name: string = "";

    createDirectoryFactory(object: any): IIODirectory {
        return new FileSystemDirectory()
    }
    createFile(obj: any): IFile {
        return new FileSystemFile()
    }
    getTextReader(obj: any, url: string): ITextReader {
        return new StreamReader(url)
    }

    public setFactory(factory: IFactory): void {
        let ff = new FileSystemFactory();
        factory.addFactory<ITextReaderFactory>(ff, "ITextReaderFactory")
        factory.addFactory<IFileFactory>(ff, "IFileFactory")
        factory.addFactory<IIODirectoryFactory>(ff, "IIODirectoryFactory")
        factory.addFactory<IPathFactory>(ff, "IPathFactory")
    }
}

