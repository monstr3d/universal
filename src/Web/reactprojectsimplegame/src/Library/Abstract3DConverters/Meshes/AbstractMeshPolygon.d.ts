import type { EffectTexture } from "../EffectTexture";
import type { ICreateTriangles } from "../Interfaces/ICreateTriangles";
import type { IMesh } from "../Interfaces/IMesh";
import type { IMeshCreator } from "../Interfaces/IMeshCreator";
import type { ITextureIndex } from "../Interfaces/ITextureIndex";
import { Polygon } from "../Points/Polygon";
import { AbstractMesh } from "./AbstractMesh";
export declare abstract class AbstractMeshPolygon extends AbstractMesh implements ICreateTriangles {
    constructor(parent: IMesh | undefined, name: string, transformationMatrix: number[], effect: EffectTexture, polygons: Polygon[], vertices: number[][], textures: number[][], normals: number[][], tuple: ITextureIndex | undefined, creator: IMeshCreator);
    abstract createTriangles(): void;
    protected polygons: Polygon[];
}
//# sourceMappingURL=AbstractMeshPolygon.d.ts.map