"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DiffuseMaterial = void 0;
const ColorTexture_1 = require("../ColorTexture");
const SimpleMaterial_1 = require("./SimpleMaterial");
class DiffuseMaterial extends SimpleMaterial_1.SimpleMaterial {
    constructor(name, color, ambient, opacity) {
        super(name, color);
        this.opacity = 0;
        this.images = [];
        this.ambient = new ColorTexture_1.ColorTexture([1, 1, 1]);
        this.color = color;
        this.types.push("DiffuseMaterial");
        this.types.push("IImageHolder");
        this.typeName = "DiffuseMaterial";
        this.ambient = ambient;
        this.opacity = opacity;
    }
    getTextureImages() {
        return this.images;
    }
    getOpacity() {
        return this.opacity;
    }
    setOpacity(p) {
        this.opacity = p;
    }
}
exports.DiffuseMaterial = DiffuseMaterial;
//# sourceMappingURL=DiffuseMaterial.js.map