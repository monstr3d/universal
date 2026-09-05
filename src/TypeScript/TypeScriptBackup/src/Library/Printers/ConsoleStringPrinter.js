"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ConsoleStringPrinter = void 0;
const EmptyObject_1 = require("../EmptyObject");
class ConsoleStringPrinter extends EmptyObject_1.EmptyObject {
    constructor() {
        super("");
        this.types.push("IPrinter");
        this.types.push("ConsoleStringPrinter");
        this.typeName = "ConsoleStringPrinter";
    }
    print(obj) {
        console.log(obj + "");
    }
}
exports.ConsoleStringPrinter = ConsoleStringPrinter;
//# sourceMappingURL=ConsoleStringPrinter.js.map