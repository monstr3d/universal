"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TestObjectTransformer = void 0;
const CategoryObject_1 = require("../Library/CategoryObject");
class TestObjectTransformer extends CategoryObject_1.CategoryObject {
    constructor(desktop, name) {
        super(desktop, name);
        /// Fieelds
        this.coefficient = 0;
        this.inp = ["a", "b", "c", "d"];
        this.ooutp = ["a", "b", "c", "d"];
        this.a = 0;
        this.typeName = "TestObjectTransformer";
        this.types.push("IObjectTransformer");
        this.types.push("TestObjectTransformer");
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
        var a = this.convert(input[0]);
        var b = this.convert(input[1]);
        var c = this.convert(input[2]);
        var d = this.convert(input[3]);
        output[0] = this.coefficient * (a + b);
        output[1] = this.coefficient * b * c;
        output[2] = this.coefficient * (c + Math.sin(d));
    }
}
exports.TestObjectTransformer = TestObjectTransformer;
//# sourceMappingURL=TestObjectTransformer.js.map