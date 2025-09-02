"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FictiveObjectTransformer = void 0;
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
class FictiveObjectTransformer {
    getInput() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    getOutput() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    getInputType(i) {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    getOutputType(i) {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    calculate(input, output) {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
}
exports.FictiveObjectTransformer = FictiveObjectTransformer;
//# sourceMappingURL=FictiveObjectTransformer.js.map