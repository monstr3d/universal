import type { IFunc } from "../../Interfaces/IFunc";
import type { IMesh } from "../Interfaces/IMesh";
import { EffectTexture } from "../EffectTexture";
import { PointTexture } from "./PointTexture";
export declare class Polygon {
    protected caclualateVertexNormal: IFunc<number[]>;
    protected vertexNormal: number[];
    protected normal: number[];
    protected mesh: IMesh;
    getMesh(): IMesh;
    points: PointTexture[];
    getPoints(): PointTexture[];
    effect: EffectTexture;
    getEffect(): EffectTexture;
    normalCalc: boolean;
    constructor(mesh: IMesh, points: PointTexture[], effect: EffectTexture | undefined);
    copy(mesh: IMesh): void;
    setNormals(): void;
}
//# sourceMappingURL=Polygon.d.ts.map