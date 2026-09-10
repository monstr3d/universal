import type { EffectTexture } from "../EffectTexture";
import type { ICreateTriangles } from "../Interfaces/ICreateTriangles";
import type { IMesh } from "../Interfaces/IMesh";
import type { IMeshCreator } from "../Interfaces/IMeshCreator";
import type { ITextureIndex } from "../Interfaces/ITextureIndex";
import { Polygon } from "../Points/Polygon";
import { AbstractMesh } from "./AbstractMesh";

export abstract class AbstractMeshPolygon extends AbstractMesh implements ICreateTriangles {

    constructor(parent: IMesh | undefined, name: string, transformationMatrix: number[], effect: EffectTexture, polygons: Polygon[],
        vertices: number[][], textures: number[][], normals: number[][], tuple: ITextureIndex | undefined, creator: IMeshCreator)
    {
        super(parent, name, transformationMatrix, effect, vertices, textures, normals, tuple, creator)
        this.polygons = polygons
    }

    abstract createTriangles(): void

    protected polygons: Polygon[] = []

}