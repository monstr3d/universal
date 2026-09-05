"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PhongMaterial = void 0;
const MaterialGroup_1 = require("./MaterialGroup");
class PhongMaterial extends MaterialGroup_1.MaterialGroup {
    constructor(name) {
        super(name);
        this.types.push("PhongMategial");
        this.typeName = "PhongMategial";
    }
}
exports.PhongMaterial = PhongMaterial;
//# sourceMappingURL=PhongMaterial.js.map