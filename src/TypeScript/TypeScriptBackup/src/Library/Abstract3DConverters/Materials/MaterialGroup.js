"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.MaterialGroup = void 0;
const Material_1 = require("./Material");
class MaterialGroup extends Material_1.Material {
    constructor(name) {
        super(name);
        this.materials = [];
        this.types.push("IChildrenT<Material>");
        this.types.push("MaterialGroup");
        this.typeName = "MaterialGroup";
    }
    getChildernT() {
        return this.materials;
    }
    addChildT(child) {
        this.materials.push(child);
    }
    removeChildT(child) {
        this.performer.remove(this.materials, child);
    }
}
exports.MaterialGroup = MaterialGroup;
//# sourceMappingURL=MaterialGroup.js.map