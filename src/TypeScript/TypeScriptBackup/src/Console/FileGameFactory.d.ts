import { IGameActionFactory } from "../Library/Game/Interfaces/IGameActionFactory";
import { IPath } from "../Library/IO/Interfaces/IPath";
import { Motion6DFactory } from "../Library/Motion6D/Motion6DFactory";
export declare class FileGameFactory extends Motion6DFactory {
    rpath: string;
    path: IPath;
    constructor(path: string, gameActionFactory: IGameActionFactory);
}
//# sourceMappingURL=FileGameFactory.d.ts.map