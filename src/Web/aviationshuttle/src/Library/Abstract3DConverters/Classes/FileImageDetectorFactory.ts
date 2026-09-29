import type { IFileFactory } from "../../IO/Interfaces/IFileFactory";
import type { IImageDetector } from "../Interfaces/IImageDetector";
import type { IImageDetectorFactory } from "../Interfaces/IImageDetectorFactory";
import { FileImageDetector } from "./FileImageDetector";

export class FileImageDetectorFactory implements IImageDetectorFactory {

    constructor(factory: IFileFactory) {
        this.factory = factory
    }

    getImageDetector(object: any): IImageDetector {
        var f = this.factory.createFile(object)
        return new FileImageDetector(f)
    }

    factory !: IFileFactory

}