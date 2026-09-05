import { GamePerformer } from "../Game/GamePerformer";
import type { IObject } from "../Interfaces/IObject";
import { Motion6DPerformer } from "../Motion6D/Motion6DPerformer";
import { ReferenceFrame } from "../Motion6D/ReferenceFrame";
import type { IMeshFrame } from "./Interfaces/IMeshFrame";
export declare class Game3DPerformer extends GamePerformer {
    pefrormer: Motion6DPerformer;
    getRelativeFrame(baseFrame: ReferenceFrame, targetFrame: ReferenceFrame, relative: ReferenceFrame): void;
    detectMeshFrame(obj: IObject): IMeshFrame | undefined;
    setInvertedCoorfinates(x: number[], z: number[], frame: ReferenceFrame): void;
    setInvertedCoorfinates2(xx: number[][], zz: number[][], frame: ReferenceFrame): void;
    getOwnFrame(object: IObject): ReferenceFrame | undefined;
}
//# sourceMappingURL=Game3DPerformer.d.ts.map