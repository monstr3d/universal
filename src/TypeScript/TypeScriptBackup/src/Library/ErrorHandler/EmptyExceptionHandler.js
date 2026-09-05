"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EmptyExceptionHandler = void 0;
class EmptyExceptionHandler {
    handleException(exception, obj) {
        this.any = exception;
        this.any = obj;
        console.log("EXCEPTION", exception);
    }
    log(message, obj) {
        this.any = message;
        this.any = obj;
    }
}
exports.EmptyExceptionHandler = EmptyExceptionHandler;
//# sourceMappingURL=EmptyExceptionHandler.js.map