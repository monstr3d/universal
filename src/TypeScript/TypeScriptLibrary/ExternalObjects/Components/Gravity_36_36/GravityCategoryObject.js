"use strict";
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
Object.defineProperty(exports, "__esModule", { value: true });
exports.GravityCategoryObject = void 0;
const Performer_1 = require("../../../Library/Performer");
const Gravity_1 = require("./Gravity.");
class GravityCategoryObject extends Gravity_1.Gravity {
    constructor(desktop, name) {
        super();
        this.performer = new Performer_1.Performer();
        this.obj = new Object();
        this.name = "";
        this.types = ["IObject", "ICategoryObject", "IObjectTransformer", "GravityCategoryObject"];
        this.typeName = "GravityCategoryObject";
        this.a = 0;
        this.inp = ["x", "y", "z"];
        this.ooutp = ["Gx", "Gy", "Gz"];
        this.fx = new Array(1);
        this.fy = new Array(1);
        this.fz = new Array(1);
        this.desktop = desktop;
        this.name = name;
        desktop.addCategoryObject(this);
        desktop.addObject(this);
        this.n0 = 36;
        this.nk = 36;
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
        var x = this.convert(input[0]);
        var y = this.convert(input[1]);
        var z = this.convert(input[2]);
        this.Forces(x, y, z, this.fx, this.fy, this.fz);
        output[0] = this.fx[0];
        output[1] = this.fy[0];
        output[2] = this.fz[0];
    }
    getClassName() {
        return this.typeName;
    }
    imlplementsType(type) {
        return this.types.indexOf(type) >= 0;
    }
    getName() {
        return this.name;
    }
    getObject() {
        return this.obj;
    }
    setObject(obj) {
        this.obj = obj;
    }
    getCategoryObjectName() {
        return this.name;
    }
    getDesktop() {
        return this.desktop;
    }
    convert(x) {
        return this.performer.convertFromAny(x);
    }
}
exports.GravityCategoryObject = GravityCategoryObject;
//# sourceMappingURL=GravityCategoryObject.js.map