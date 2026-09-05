"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EmptyActionT = void 0;
const AbstractActionT_1 = require("./AbstractActionT");
class EmptyActionT extends AbstractActionT_1.AbstractActionT {
    constructor() {
        super();
        this.typeName = "EmptyActionT";
        this.types.push("EmptyActionT");
    }
    actionT(t) {
        this.t = t;
    }
    isEmptyActionT() {
        return true;
    }
}
exports.EmptyActionT = EmptyActionT;
//# sourceMappingURL=EmptyActionT.js.map