"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SimpleMaterial = void 0;
const ColorTexture_1 = require("../ColorTexture");
const Material_1 = require("./Material");
class SimpleMaterial extends Material_1.Material {
    constructor(name, color) {
        super(name);
        this.color = new ColorTexture_1.ColorTexture([]);
        this.color = color;
        this.types.push("SimpleMaterial");
        this.typeName = "SimpleMaterial";
    }
}
exports.SimpleMaterial = SimpleMaterial;
//# sourceMappingURL=SimpleMaterial.js.map