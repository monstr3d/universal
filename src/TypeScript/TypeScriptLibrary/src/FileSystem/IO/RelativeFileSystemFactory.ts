import { IFactory } from "../../Library/Interfaces/IFactory";
import { IFile } from "../../Library/IO/Interfaces/IFile";
import { IFileFactory } from "../../Library/IO/Interfaces/IFileFactory";
import { IIODirectory } from "../../Library/IO/Interfaces/IIODirectory";
import { IIODirectoryFactory } from "../../Library/IO/Interfaces/IIODirectoryFactory";
import { IPath } from "../../Library/IO/Interfaces/IPath";
import { IPathFactory } from "../../Library/IO/Interfaces/IPathFactory";
import { ITextReader } from "../../Library/IO/Interfaces/ITextReader";
import { ITextReaderFactory } from "../../Library/IO/Interfaces/ITextReaderFactory";
import { FilePath } from "./FilePath";
import { FileSystemFactory } from "./FileSystemFactory";
import { RelativeFileSystemDirectory } from "./RelativeFileSystemDirectory";
import { RelativeFileSystemFile } from "./RelativeFileSystemFile";
import { StreamReader } from "./StreamReader";

export class RelativeFileSystemFactory extends FileSystemFactory {

    rpath: string = "";

    path: IPath = new FilePath()
    constructor(path: string) {
        super()
        this.typeName = "RelativeFileSystemFactory"
        this.types.push("RelativeFileSystemFactory")
        this.rpath = path;
    }

    createDirectoryFactory(object: any): IIODirectory {
        return new RelativeFileSystemDirectory(this.rpath)
    }
    createFile(obj: any): IFile {
        return new RelativeFileSystemFile(this.rpath)
    }
    getTextReader(obj: any, url: string): ITextReader {
        let d = this.path.pathCombine(this.rpath, url)
        return new StreamReader(d)
    }

    public setFactory(factory: IFactory): void {
        factory.addFactory<ITextReaderFactory>(this, "ITextReaderFactory")
        factory.addFactory<IFileFactory>(this, "IFileFactory")
        factory.addFactory<IIODirectoryFactory>(this, "IIODirectoryFactory")
        factory.addFactory<IPathFactory>(this, "IPathFactory")
    }

}
