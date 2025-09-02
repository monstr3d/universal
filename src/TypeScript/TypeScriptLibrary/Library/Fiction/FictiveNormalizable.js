"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FictiveNormalizable = void 0;
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
class FictiveNormalizable {
    normalize() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
}
exports.FictiveNormalizable = FictiveNormalizable;
//# sourceMappingURL=FictiveNormalizable.js.map