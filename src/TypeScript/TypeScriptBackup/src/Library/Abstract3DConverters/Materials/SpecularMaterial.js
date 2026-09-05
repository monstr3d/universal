"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SpecularMaterial = void 0;
const SimpleMaterial_1 = require("./SimpleMaterial");
class SpecularMaterial extends SimpleMaterial_1.SimpleMaterial {
    constructor(name, color, power) {
        super(name, color);
        this.specularPower = 0;
        this.specularPower = power;
    }
    getSpecularPower() {
        return this.specularPower;
    }
    setSpecularPover(p) {
        this.specularPower = p;
    }
}
exports.SpecularMaterial = SpecularMaterial;
//# sourceMappingURL=SpecularMaterial.js.map