import type { IPath } from "./IPath";

export interface IPathFactory {
    createPath(obj: any): IPath
}