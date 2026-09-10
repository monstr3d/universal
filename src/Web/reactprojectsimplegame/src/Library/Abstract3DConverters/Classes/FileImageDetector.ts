import type { IFile } from "../../IO/Interfaces/IFile";
import type { IImageDetector } from "../Interfaces/IImageDetector";

export class FileImageDetector implements IImageDetector {
    constructor(fileDetector: IFile) {
        this.fileDetector = fileDetector;
    }

    detectImage(file: string): boolean {
        return this.fileDetector.existsFile(file);
    }

    fileDetector !: IFile

}
