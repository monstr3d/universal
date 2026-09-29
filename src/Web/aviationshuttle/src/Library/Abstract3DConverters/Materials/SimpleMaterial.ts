import { ColorTexture } from "../ColorTexture";
import { ImageTexture } from "../ImageTexture";
import { Material } from "./Material";

export class SimpleMaterial extends Material {

    constructor(name : string, color: ColorTexture) {
        super(name)
        this.color = color
        this.types.push("SimpleMaterial")
        this.typeName = "SimpleMaterial"
    }
    protected color: ColorTexture = new ColorTexture([])

    protected image !: ImageTexture


}