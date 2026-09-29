import { ImageTexture } from "./ImageTexture";
import { Material } from "./Materials/Material";

export class EffectTexture {

    constructor(effects: Map<string, EffectTexture>, name: string, material: Material, image: ImageTexture) {
        this.name = name
        this.material = material
        this.image = image
        if (!effects.has(name)) {
            effects.set(name, this)
        }
    }

    material !: Material

    image !: ImageTexture

    name: string = ""

}