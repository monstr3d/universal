"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EmissiveMaterial = void 0;
const SimpleMaterial_1 = require("./SimpleMaterial");
class EmissiveMaterial extends SimpleMaterial_1.SimpleMaterial {
    constructor(name, color, image) {
        super(name, color);
        this.image = image;
    }
}
exports.EmissiveMaterial = EmissiveMaterial;
//# sourceMappingURL=EmissiveMaterial.js.map