import { ColorTexture } from "../ColorTexture";
import type { ImageTexture } from "../ImageTexture";
import type { IImageHolder } from "../Interfaces/IImageHolder";
import { SimpleMaterial } from "./SimpleMaterial";

export class DiffuseMaterial extends SimpleMaterial implements IImageHolder {
    constructor(name: string, color: ColorTexture, ambient: ColorTexture, opacity: number) {
        super(name, color)
        this.color = color
        this.types.push("DiffuseMaterial")
        this.types.push("IImageHolder")
        this.typeName = "DiffuseMaterial"
        this.ambient = ambient
        this.opacity = opacity
    }
    

    getTextureImages(): ImageTexture[] {
        return this.images
    }

    getOpacity(): number {
        return this.opacity
    }

    setOpacity(p: number) {
        this.opacity = p
    }

    opacity: number = 0;

    images: ImageTexture[] = []

    ambient: ColorTexture = new ColorTexture([1, 1, 1])
}