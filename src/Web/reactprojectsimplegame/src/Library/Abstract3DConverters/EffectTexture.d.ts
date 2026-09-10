import { ImageTexture } from "./ImageTexture";
import { Material } from "./Materials/Material";
export declare class EffectTexture {
    constructor(effects: Map<string, EffectTexture>, name: string, material: Material, image: ImageTexture);
    material: Material;
    image: ImageTexture;
    name: string;
}
//# sourceMappingURL=EffectTexture.d.ts.map