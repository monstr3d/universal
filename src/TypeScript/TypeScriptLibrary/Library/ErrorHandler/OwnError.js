"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.OwnError = void 0;
/* eslint-disable @typescript-eslint/no-unused-vars */
class OwnError {
    constructor(name, message, stack) {
        this.name = "";
        this.message = "";
        this.name = name;
        this.message = message;
        this.stack = stack;
        this.init();
    }
    init() {
    }
}
exports.OwnError = OwnError;
//# sourceMappingURL=OwnError.js.map