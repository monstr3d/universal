import { EmptyObject } from "../../Library/EmptyObject";
import type { IPath } from "../../Library/IO/Interfaces/IPath";
import type { IResourceFunc } from "../../Library/Resources/Infrefaces/IResourceFunc";
export declare abstract class FileResourceFunc extends EmptyObject implements IResourceFunc {
    constructor(directory: string);
    abstract functT(s: string): any;
    protected directory: string;
    protected getFillPath(path: string): string;
    protected path: IPath;
}
//# sourceMappingURL=FileResourceFunc.d.ts.map