import { EmptyObject } from "../../Library/EmptyObject";
import type { IPath } from "../../Library/IO/Interfaces/IPath";
import { PurePath } from "../../Library/IO/PurePath";
import type { IResourceFunc } from "../../Library/Resources/Infrefaces/IResourceFunc";
import type { IResourceItem } from "../../Library/Resources/Infrefaces/IResourceItem";

export abstract class FileResourceFunc extends EmptyObject implements IResourceFunc {
    constructor(directory: string) {
        super("")
        this.types.push("FileResourceFunc")
        this.types.push("IResourceFunc")
        this.typeName = "FileResourceFunc";
        this.directory = directory
    }

    abstract functT(s: string): any

    protected directory: string = "";

    protected getFillPath(path: string): string {
        return this.path.pathCombine(this.directory, path)

    }

    protected path: IPath = new PurePath();
}