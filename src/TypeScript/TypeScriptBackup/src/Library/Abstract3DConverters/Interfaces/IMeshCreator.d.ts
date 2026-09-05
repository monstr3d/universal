import type { IFactory } from "../../Interfaces/IFactory";
import type { IObject } from "../../Interfaces/IObject";
import type { IUrlObject } from "../../IO/Interfaces/IUrlObject";
import type { IMesh } from "./IMesh";
import { EffectTexture } from "../EffectTexture";
export interface IMeshCreator extends IObject, IUrlObject {
    loadMeshCreator(): void;
    getMeshCreatorMeshes(): IMesh[];
    getMeshCreatorEffects(): Map<string, EffectTexture>;
    getMeshCreatorFactory(): IFactory;
    getMeshCreatorGenerator(): any;
    getMeshCreatorDirectory(): string;
}
//# sourceMappingURL=IMeshCreator.d.ts.map