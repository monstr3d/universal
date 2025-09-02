"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FictiveValue = void 0;
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
class FictiveValue {
    getIValue() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    setIValue(value) {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
}
exports.FictiveValue = FictiveValue;
//# sourceMappingURL=FictiveValue.js.map