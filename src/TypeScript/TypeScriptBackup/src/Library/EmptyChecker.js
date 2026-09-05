"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EmptyChecker = void 0;
const EmptyObject_1 = require("./EmptyObject");
class EmptyChecker extends EmptyObject_1.EmptyObject {
    constructor() {
        super("");
        this.types.push("ICheck");
        this.types.push("EmptyChecker");
        this.typeName = "EmptyChecker";
    }
    check(o) {
        return o == undefined;
    }
}
exports.EmptyChecker = EmptyChecker;
//# sourceMappingURL=EmptyChecker.js.map