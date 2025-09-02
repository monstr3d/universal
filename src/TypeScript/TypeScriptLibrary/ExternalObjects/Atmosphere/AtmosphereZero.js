"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AtmosphereZero = void 0;
const CategoryObject_1 = require("../../Library/CategoryObject");
class AtmosphereZero extends CategoryObject_1.CategoryObject {
    constructor(desktop, name) {
        super(desktop, name);
        this.inp = ["t", "x", "y", "z"];
        this.ooutp = ["Density"];
        this.a = 0;
        this.types.push("IObjectTransformer");
        this.types.push("AtmosphereZero");
        this.typeName = "AtmosphereZero";
    }
    getInput() {
        return this.inp;
    }
    getOutput() {
        return this.ooutp;
    }
    getInputType(i) {
        return this.a;
    }
    getOutputType(i) {
        return this.a;
    }
    calculate(input, output) {
        output[0] = 0;
    }
}
exports.AtmosphereZero = AtmosphereZero;
//# sourceMappingURL=AtmosphereZero.js.map