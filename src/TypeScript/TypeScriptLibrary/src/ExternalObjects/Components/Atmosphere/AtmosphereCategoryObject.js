"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AtmosphereCategoryObject = void 0;
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
const OwnNotImplemented_1 = require("../../../Library/ErrorHandler/OwnNotImplemented");
const AtmospherePure_1 = require("./AtmospherePure");
const Performer_1 = require("../../../Library/Performer");
class AtmosphereCategoryObject extends AtmospherePure_1.AtmospherePure {
    constructor(desktop, name) {
        super();
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
        this.any = i;
        return this.a;
    }
    getOutputType(i) {
        this.any = i;
        return this.a;
    }
    calculate(input, output) {
        var t = this.performer.convertFromAny(input[0]);
        this.x[0] = this.performer.convertFromAny(input[1]);
        this.x[1] = this.performer.convertFromAny(input[2]);
        this.x[2] = this.performer.convertFromAny(input[3]);
        var r = this.atmosphere(t, this.x);
        output[0] = r;
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
        this.any = obj;
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    getCategoryObjectName() {
        return this.name;
    }
    getDesktop() {
        return this.desktop;
    }
    name = "";
    types = ["IObject", "ICategoryObject", "IObjectTransformer", "AtmospherePure", "AtmosphereCategoryObject"];
    any;
    desktop;
    checker;
    inp = ["t", "x", "y", "z"];
    ooutp = ["Density"];
    a = 0;
    x = [0, 0, 0];
    performer = new Performer_1.Performer();
}
exports.AtmosphereCategoryObject = AtmosphereCategoryObject;
