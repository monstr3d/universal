"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.OwnNotImplemented = void 0;
/* eslint-disable @typescript-eslint/no-unused-vars */
const OwnError_1 = require("./OwnError");
class OwnNotImplemented extends OwnError_1.OwnError {
    constructor(m) {
        super(m, "Method not implemented", undefined);
    }
    ;
}
exports.OwnNotImplemented = OwnNotImplemented;
//# sourceMappingURL=OwnNotImplemented.js.map