"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AtmosphereCategoryObject = void 0;
const OwnNotImplemented_1 = require("../../Library/ErrorHandler/OwnNotImplemented");
const FictiveDesktop_1 = require("../../Library/Fiction/FictiveDesktop");
const AtmospherePure_1 = require("./AtmospherePure");
class AtmosphereCategoryObject extends AtmospherePure_1.AtmospherePure {
    constructor(desktop, name) {
        super();
        this.name = "";
        this.types = ["IObject", "ICategoryObject", "IObjectTransformer", "AtmospherePure", "AtmosphereCategoryObject"];
        this.desktop = new FictiveDesktop_1.FictiveDesktop();
        this.inp = ["t", "x", "y", "z"];
        this.ooutp = ["Density"];
        this.a = 0;
        this.desktop = desktop;
        this.name = name;
        desktop.addCategoryObject(this);
        desktop.addObject(this);
        this.checker = desktop.getCheck();
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
    getClassName() {
        throw "AtmosphereCategoryObject";
    }
    imlplementsType(type) {
        return this.types.indexOf(type) > 0;
    }
    getName() {
        return this.name;
    }
    getObject() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    setObject(obj) {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    getCategoryObjectName() {
        return this.name;
    }
    getDesktop() {
        return this.desktop;
    }
}
exports.AtmosphereCategoryObject = AtmosphereCategoryObject;
//# sourceMappingURL=AtmosphereCategoryObject.js.map