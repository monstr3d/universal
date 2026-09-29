import type { INodeT } from "../../NamedTree/Interfaces/INodeT";
import type { IMesh } from "../Interfaces/IMesh";
import type { IMeshCreator } from "../Interfaces/IMeshCreator";
import type { ITextureIndex } from "../Interfaces/ITextureIndex";
import type { IGeometry } from "../Interfaces/IGeometry";
import { Performer } from "../../Performer";
import { EffectTexture } from "../EffectTexture";
import { Converter3DPefrormer } from "../Converter3DPerformer";
import { PointTexture } from "../Points/PointTexture";

export class AbstractMesh implements IMesh {


    constructor(parent: IMesh | undefined, name: string, transformationMatrix: number[], effect: EffectTexture | undefined,
        vertices: number[][], textures: number[][], normals: number[][], tuple: ITextureIndex | undefined, creator: IMeshCreator)
    {
        if (tuple != null) this.tuple = tuple
        if (parent != undefined) {
            this.parent = parent
            parent.addNodeT(this)
        }
        this.name = name
        this.transformationMatrix = transformationMatrix
        if (effect != undefined)  this.effect = effect
        this.vertices = vertices
        this.textures = textures
        this.normals = normals
        this.creator = creator
    }
    getIndexes(): number[][][] {
        return this.indexes
    }
    getAbsoluteVertices(): number[][] {
        return this.vertices;
    }


    getEffect(): EffectTexture {
        return this.effect;
    }
    calculateAbsolute(): void {
        
    }

    protected tuple !: ITextureIndex

    protected creator !: IMeshCreator


    protected typeName: string = "AbstractMesh";

    protected types: string[] = ["IObject", "IMesh", "INodeT<IMesh>", "IGeometry", "INamed", "AbstractMesh"];

    protected name: string = "";

    getVertices(): number[][] {
        return this.vertices;
    }
    getNormals(): number[][] {
        return this.normals
    }
    getTextures(): number[][] {
        return this.textures;
    }
    getTransformationMatrix(): number[] {
        return this.transformationMatrix
    }
    getNamedName(): string {
        return this.name
    }

    setNamedName(name: string): void {
        this.name = name;
    }
 
    getName(): string {
        return this.name;
    }


    getClassName(): string {
        return this.typeName;
    }

    imlplementsType(type: string): boolean {
        return this.types.includes(type);
    }

  
    getParentT(): INodeT<IMesh> | undefined {
        return this.parent;
    }
    setParentT(parent: INodeT<IMesh>): void {
        this.parent = parent;
    }
    getNodesT(): INodeT<IMesh>[] {
        return this.nodes
    }
    addNodeT(node: INodeT<IMesh>): void {
        this.nodes.push(node)
    }
    removeNodeT(node: INodeT<IMesh>): void {
        this.performer.remove<INodeT<IMesh>>(this.nodes, node)
    }
    getNodeValueT(): IMesh {
        return this;
    }

    public createPointTexture(geometry: IGeometry, vertex: number, texture: number, normal: number): PointTexture {
        return this.cPerformer.createPointTexture(geometry, vertex, texture, normal)
    }

    protected toFloat(s: string): number {
        return this.performer.convert<string, number>(s)
    }

    cPerformer: Converter3DPefrormer = new Converter3DPefrormer()


    performer : Performer = new Performer()

    parent !: INodeT<IMesh> 

    nodes: INodeT<IMesh>[] = []

    effect !: EffectTexture


    transformationMatrix: number[] = []
    textures: number[][] = []
    normals: number[][] = []
    vertices: number[][] = []
    indexes: number[][][] = []

    absolutevertices: number[][] = []

}