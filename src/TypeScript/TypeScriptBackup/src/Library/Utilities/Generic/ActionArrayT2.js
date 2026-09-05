"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ActionArrayT2 = void 0;
const EmptyObject_1 = require("../../EmptyObject");
class ActionArrayT2 extends EmptyObject_1.EmptyObject {
    constructor() {
        super("");
        this.actions = [];
        this.types.push("IActionAddRemoveT2");
        this.types.push("ActionArrayT2");
        this.typeName = "ActionArrayT2";
    }
    isEmptyActionT2() {
        return this.actions.length == 0;
    }
    addActionT2(action) {
        if (this.performer.isEmptyActionT2(action))
            return;
        if (action === undefined)
            return;
        this.actions.push(action);
    }
    removeActionT2(action) {
        if (this.performer.isEmptyActionT2(action))
            return;
        if (action === undefined)
            return;
        this.performer.remove(this.actions, action);
    }
    clearActionsT2() {
        this.actions = [];
    }
    actionT2(t1, t2) {
        for (let action of this.actions)
            action.actionT2(t1, t2);
    }
}
exports.ActionArrayT2 = ActionArrayT2;
//# sourceMappingURL=ActionArrayT2.js.map