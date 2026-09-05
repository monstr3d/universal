import { ColorTexture } from "../ColorTexture";
import type { ImageTexture } from "../ImageTexture";
import type { IImageHolder } from "../Interfaces/IImageHolder";
import { SimpleMaterial } from "./SimpleMaterial";
export declare class DiffuseMaterial extends SimpleMaterial implements IImageHolder {
    constructor(name: string, color: ColorTexture, ambient: ColorTexture, opacity: number);
    getTextureImages(): ImageTexture[];
    getOpacity(): number;
    setOpacity(p: number): void;
    opacity: number;
    images: ImageTexture[];
    ambient: ColorTexture;
}
//# sourceMappingURL=DiffuseMaterial.d.ts.map