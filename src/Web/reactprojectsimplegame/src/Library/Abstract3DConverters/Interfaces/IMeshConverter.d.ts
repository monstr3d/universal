import type { IMaterialCreator } from "./IMaterialCreator";
import { EffectTexture } from "../EffectTexture";
import type { IMesh } from "./IMesh";
export interface IMeshConverter {
    getMeshCoverterDirectory(): string;
    getMeshCoverterMaterialCreator(): IMaterialCreator;
    getMeshCoverterFffects(): Map<string, EffectTexture>;
    createFromMesh(mesh: IMesh): any;
    setEffectToMesh(mesh: any, effect: any): void;
    addParentMesh(parent: any, child: any): void;
    combineMeshes(meshes: any[]): void;
    setMeshTransformation(mesh: any, transformation: number[]): void;
    getMeshFilename(): string;
}
//# sourceMappingURL=IMeshConverter.d.ts.map