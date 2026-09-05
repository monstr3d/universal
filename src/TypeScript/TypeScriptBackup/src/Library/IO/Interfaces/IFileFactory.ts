import type { IFile } from "./IFile";

export interface IFileFactory {
    createFile(obj: any): IFile
}