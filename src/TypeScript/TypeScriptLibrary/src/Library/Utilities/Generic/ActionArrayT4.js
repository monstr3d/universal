"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ActionArrayT4 = void 0;
const EmptyObject_1 = require("../../EmptyObject");
class ActionArrayT4 extends EmptyObject_1.EmptyObject {
    constructor() {
        super("");
        this.types.push("IActionAddRemoveT4");
        this.types.push("ActionArrayT4");
        this.typeName = "ActionArrayT4";
    }
    isEmptyActionT4() {
        return this.actions.length == 0;
    }
    addActionT4(action) {
        if (this.performer.isEmptyActionT4(action))
            return;
        if (action === undefined)
            return;
        this.actions.push(action);
    }
    removeActionT4(action) {
        if (this.performer.isEmptyActionT4(action))
            return;
        if (action === undefined)
            return;
        this.performer.remove(this.actions, action);
    }
    clearActionsT4() {
        this.actions = [];
    }
    actionT4(t1, t2, t3, t4) {
        for (let action of this.actions)
            action.actionT4(t1, t2, t3, t4);
    }
    actions = [];
}
exports.ActionArrayT4 = ActionArrayT4;
