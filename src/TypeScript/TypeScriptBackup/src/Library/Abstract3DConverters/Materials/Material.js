"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Material = void 0;
const Performer_1 = require("../../Performer");
class Material {
    constructor(name) {
        this.typeName = "Material";
        this.types = ["IObject", "INamed", "Material"];
        this.performer = new Performer_1.Performer();
        this.namedName = "";
        this.namedName = name;
    }
    getNamedName() {
        return this.namedName;
    }
    setNamedName(name) {
        this.namedName = name;
    }
    getName() {
        return this.namedName;
    }
    getClassName() {
        return this.typeName;
    }
    imlplementsType(type) {
        return this.types.includes(type);
    }
}
exports.Material = Material;
//# sourceMappingURL=Material.js.map