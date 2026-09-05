import { ColorTexture } from "../ColorTexture";
import { SimpleMaterial } from "./SimpleMaterial";

export class SpecularMaterial extends SimpleMaterial {

    constructor(name: string, color: ColorTexture, power: number) {
        super(name, color)
        this.specularPower = power
    }

    getSpecularPower(): number {
        return this.specularPower
    }

    setSpecularPover(p: number) {
        this.specularPower = p
    }

    specularPower: number = 0;
}