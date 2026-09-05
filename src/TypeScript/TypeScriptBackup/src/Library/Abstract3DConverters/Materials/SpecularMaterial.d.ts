import { ColorTexture } from "../ColorTexture";
import { SimpleMaterial } from "./SimpleMaterial";
export declare class SpecularMaterial extends SimpleMaterial {
    constructor(name: string, color: ColorTexture, power: number);
    getSpecularPower(): number;
    setSpecularPover(p: number): void;
    specularPower: number;
}
//# sourceMappingURL=SpecularMaterial.d.ts.map