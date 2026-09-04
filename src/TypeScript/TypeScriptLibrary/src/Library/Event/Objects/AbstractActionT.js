"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractActionT = void 0;
const EmptyObject_1 = require("../../EmptyObject");
class AbstractActionT extends EmptyObject_1.EmptyObject {
    constructor(func) {
        super("");
        if (func != undefined)
            this.func = func;
        this.typeName = "AbstractActionT";
        this.types.push("IActionT");
        this.types.push("AbstractActionT");
    }
    isProhibited(show) {
        if (this.func == undefined)
            return false;
        let b = this.func.functT(show);
        if (b == undefined)
            return false;
        return !b;
    }
    isEmptyActionT() {
        return false;
    }
    func;
}
exports.AbstractActionT = AbstractActionT;
