import type { IGeometry } from "../Interfaces/IGeometry";
import { Polygon } from "./Polygon";
export declare class PointTexture {
    constructor(geometry: IGeometry, vertex: number, texture: number, normal: number);
    protected geometry: IGeometry;
    getGeometry(): IGeometry | undefined;
    protected vertex: number[];
    getVertex(): number[];
    protected texture: number[];
    getTexture(): number[];
    protected normal: number[];
    getNormal(): number[];
    protected vertexIndex: number;
    getVertexIndex(): number;
    protected textureIndex: number;
    getTextureIndex(): number;
    protected normalIndex: number;
    getNormalIndex(): number;
    protected polygon: Polygon;
    getPolygon(): Polygon;
    setPolygon(polyon: Polygon): void;
    copy(geometry: IGeometry): void;
}
//# sourceMappingURL=PointTexture.d.ts.map