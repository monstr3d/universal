"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractAction = void 0;
const EmptyObject_1 = require("../../EmptyObject");
class AbstractAction extends EmptyObject_1.EmptyObject {
    constructor() {
        super("");
        this.typeName = "AbstractAction";
        this.types.push("IAction");
        this.types.push("AbstractAction");
    }
    isEmptyAction() {
        return false;
    }
}
exports.AbstractAction = AbstractAction;
//# sourceMappingURL=AbstractAction.js.map