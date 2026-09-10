import type { IFile } from "../../IO/Interfaces/IFile";
import type { IImageDetector } from "../Interfaces/IImageDetector";
export declare class FileImageDetector implements IImageDetector {
    constructor(fileDetector: IFile);
    detectImage(file: string): boolean;
    fileDetector: IFile;
}
//# sourceMappingURL=FileImageDetector.d.ts.map