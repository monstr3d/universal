import type { IFileFactory } from "../../IO/Interfaces/IFileFactory";
import type { IImageDetector } from "../Interfaces/IImageDetector";
import type { IImageDetectorFactory } from "../Interfaces/IImageDetectorFactory";
export declare class FileImageDetectorFactory implements IImageDetectorFactory {
    constructor(factory: IFileFactory);
    getImageDetector(object: any): IImageDetector;
    factory: IFileFactory;
}
//# sourceMappingURL=FileImageDetectorFactory.d.ts.map