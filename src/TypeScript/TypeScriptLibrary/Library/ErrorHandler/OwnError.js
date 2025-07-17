"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.OwnError = void 0;
class OwnError {
    constructor(name, message, stack) {
        this.init();
        this.name = name;
        this.message = message;
        this.stack = stack;
    }
    init() {
    }
}
exports.OwnError = OwnError;
//# sourceMappingURL=OwnError.js.map