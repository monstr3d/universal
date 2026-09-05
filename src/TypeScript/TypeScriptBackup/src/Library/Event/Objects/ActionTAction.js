"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ActionTAction = void 0;
const EmptyObject_1 = require("../../EmptyObject");
class ActionTAction extends EmptyObject_1.EmptyObject {
    constructor(action) {
        super("");
        this.typeName = "ActionTAction";
        this.types.push("IActionT");
        this.types.push("ActionTAction");
        this.action = action;
    }
    actionT(t) {
        this.any = t;
        this.action.action();
    }
    isEmptyActionT() {
        return false;
    }
}
exports.ActionTAction = ActionTAction;
//# sourceMappingURL=ActionTAction.js.map