import type { IFile } from "../IO/Interfaces/IFile";
import { Performer } from "../Performer";
import { ColorTexture } from "./ColorTexture";
import type { IGeometry } from "./Interfaces/IGeometry";
import { PointTexture } from "./Points/PointTexture";
export declare class Converter3DPefrormer {
    performer: Performer;
    toReal(s: string): number;
    toRealArray(str: string): number[];
    createPointTexture(geometry: IGeometry, vertex: number, texture: number, normal: number): PointTexture;
    getTextureCoordinate(a: number): number;
    addTexture(l: number[][], texture: number[]): void;
    stringToColor(str: string, hex: boolean): ColorTexture;
    fileExists(filename: string, file: IFile): boolean;
    toShiftString(str: string, shift: string): string;
}
//# sourceMappingURL=Converter3DPerformer.d.ts.map