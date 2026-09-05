import { EffectTexture } from "../EffectTexture";
import type { IMesh } from "../Interfaces/IMesh";
import type { ITextureIndex } from "../Interfaces/ITextureIndex";
import { Obj3DCreator } from "../MeshCreators/Obj3DCreator";
import { Polygon } from "../Points/Polygon";
import { AbstractMeshPolygon } from "./AbstractMeshPolygon";
export declare class AbstractMeshObj extends AbstractMeshPolygon {
    constructor(parent: IMesh | undefined, name: string, transformationMatrix: number[], effect: EffectTexture, polygons: Polygon[], vertices: number[][], textures: number[][], normals: number[][], tuple: ITextureIndex | undefined, creatorObj: Obj3DCreator, variant: number, meshNumber: number);
    createTriangles(): void;
    protected o3dCreator: Obj3DCreator;
    protected global: Map<number, number[]>;
    np: number;
    protected shift: number;
    protected shiftTexture: number;
    protected shiftNormal: number;
    protected iindexes: ITextureIndex[];
    protected intVertices: number[][];
    protected intNormals: number[][];
    protected intTextures: number[][];
    meshNumber: number;
}
//# sourceMappingURL=AbstractMeshObj.d.ts.map