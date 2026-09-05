"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ConsolePrinter = void 0;
const EmptyObject_1 = require("../EmptyObject");
class ConsolePrinter extends EmptyObject_1.EmptyObject {
    constructor() {
        super("");
        this.types.push("IPrinter");
        this.types.push("ConsolePrinter");
        this.typeName = "ConsolePrinter";
    }
    print(obj) {
        console.log(obj);
    }
}
exports.ConsolePrinter = ConsolePrinter;
//# sourceMappingURL=ConsolePrinter.js.map