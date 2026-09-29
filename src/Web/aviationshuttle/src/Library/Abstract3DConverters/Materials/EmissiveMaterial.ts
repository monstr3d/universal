
import { ColorTexture } from "../ColorTexture";
import { ImageTexture } from "../ImageTexture";
import { SimpleMaterial } from "./SimpleMaterial";

export class EmissiveMaterial extends SimpleMaterial {
    constructor(name: string, color: ColorTexture, image: ImageTexture) {
        super(name, color)
        this.image = image
    }

}