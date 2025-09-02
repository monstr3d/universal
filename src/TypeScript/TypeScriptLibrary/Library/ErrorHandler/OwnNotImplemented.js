"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.OwnNotImplemented = void 0;
const OwnError_1 = require("./OwnError");
class OwnNotImplemented extends OwnError_1.OwnError {
    constructor() {
        super("", "Method not implemented", undefined);
    }
    ;
}
exports.OwnNotImplemented = OwnNotImplemented;
//# sourceMappingURL=OwnNotImplemented.js.map