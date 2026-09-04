import type { IChildrenT } from "../NamedTree/Interfaces/IChildrenT";

export interface IDirectory extends IChildrenT<IDirectory> {
    getDirectoryName(): string

    getFullDirectoryName(): string

    getDirectory(name: string): IDirectory

    getParentDirectory(): IDirectory | undefined
}