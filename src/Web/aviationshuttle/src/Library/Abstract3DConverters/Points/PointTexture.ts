import type { IGeometry } from "../Interfaces/IGeometry";
import { Polygon } from "./Polygon";

export class PointTexture {

    constructor(geometry: IGeometry, vertex: number, texture: number, normal: number) {
        try {
            this.geometry = geometry;
            this.vertexIndex = vertex;
            this.textureIndex = texture;
            this.normalIndex = normal;
            this.vertex = geometry.getVertices()[vertex];
            this.normal = geometry.getVertices()[vertex];
            this.texture = geometry.getTextures()[vertex];
            var nn = geometry.getNormals()
            if (nn.length == 0) {
                this.normalIndex = -1;
            }
            else if (normal >= 0) {
                this.normal = geometry.getNormals()[normal];
            }
        }
        catch (e) {

        }
    }

    protected geometry !: IGeometry

    public getGeometry(): IGeometry | undefined {
        return this.geometry
    }

    protected vertex: number[] = []

    public getVertex(): number[] {
        return this.vertex
    }


    protected texture: number[] = []

    public getTexture(): number[] {
        return this.texture
    }


    protected normal: number[] = []

    public getNormal(): number[] {
        return this.normal
    }


    protected vertexIndex: number = 0

    public getVertexIndex(): number {
        return this.vertexIndex
    }


    protected textureIndex: number = 0

    public getTextureIndex(): number {
        return this.textureIndex
    }


    protected normalIndex: number = 0

    public getNormalIndex(): number {
        return this.normalIndex
    }

    protected polygon !: Polygon

    public getPolygon(): Polygon {
        return this.polygon
    }

    public setPolygon(polyon: Polygon): void {
        this.polygon = polyon
    }


    public copy(geometry: IGeometry): void {
        this.geometry = geometry;
    }

}