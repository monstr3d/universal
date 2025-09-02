"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FictiveAlias = void 0;
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
class FictiveAlias {
    getAliasNames() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    getAliasType(name) {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    getAliasValue(name) {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    setAliasValue(name, value) {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
}
exports.FictiveAlias = FictiveAlias;
//# sourceMappingURL=FictiveAlias.js.map