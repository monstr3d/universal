import type { INodeT } from "../../NamedTree/Interfaces/INodeT";
import type { IGeometry } from "./IGeometry";
import { EffectTexture } from "../EffectTexture";
export interface IMesh extends IGeometry, INodeT<IMesh> {
    getAbsoluteVertices(): number[][];
    getEffect(): EffectTexture;
    calculateAbsolute(): void;
    getIndexes(): number[][][];
}
//# sourceMappingURL=IMesh.d.ts.map