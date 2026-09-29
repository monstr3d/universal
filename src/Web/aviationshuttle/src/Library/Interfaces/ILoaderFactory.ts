import type { ILoader } from "./ILoader";

export interface ILoaderFactory {
    getLoader(object: any): ILoader
}