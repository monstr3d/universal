import { ColorTexture } from "../ColorTexture";
import { ImageTexture } from "../ImageTexture";
import { Material } from "./Material";
export declare class SimpleMaterial extends Material {
    constructor(name: string, color: ColorTexture);
    protected color: ColorTexture;
    protected image: ImageTexture;
}
//# sourceMappingURL=SimpleMaterial.d.ts.map