"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.OwnError = void 0;
/* eslint-disable @typescript-eslint/no-unused-vars */
class OwnError {
    name = "";
    message = "";
    stack;
    constructor(name, message, stack) {
        if (name != undefined)
            this.name = name;
        this.message = message;
        this.stack = stack;
        this.init();
    }
    init() {
    }
}
exports.OwnError = OwnError;
