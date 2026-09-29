import type { IImageDetector } from "./IImageDetector";

export interface IImageDetectorFactory {

    getImageDetector(object: any): IImageDetector
}