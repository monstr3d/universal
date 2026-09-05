"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ConsoleShowObject = void 0;
const AbstractActionT_1 = require("../Event/Objects/AbstractActionT");
class ConsoleShowObject extends AbstractActionT_1.AbstractActionT {
    constructor(func) {
        super(func);
        this.i = 0;
    }
    actionT(t) {
        if (this.isProhibited(t))
            return;
        ++this.i;
        console.log("\n");
        console.log("Name ", t.name);
        console.log("Object ", t.show);
        console.log("Sender ", t.sender);
        console.log("Number ", this.i);
        console.log("\n");
    }
}
exports.ConsoleShowObject = ConsoleShowObject;
//# sourceMappingURL=ConsoleShowObject.js.map