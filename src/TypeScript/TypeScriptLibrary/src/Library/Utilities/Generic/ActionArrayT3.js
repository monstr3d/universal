"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ActionArrayT3 = void 0;
const EmptyObject_1 = require("../../EmptyObject");
class ActionArrayT3 extends EmptyObject_1.EmptyObject {
    constructor() {
        super("");
        this.types.push("IActionAddRemoveT3");
        this.types.push("ActionArrayT3");
        this.typeName = "ActionArrayT3";
    }
    isEmptyActionT3() {
        return this.actions.length == 0;
    }
    addActionT3(action) {
        if (this.performer.isEmptyActionT3(action))
            return;
        if (action === undefined)
            return;
        this.actions.push(action);
    }
    removeActionT3(action) {
        if (this.performer.isEmptyActionT3(action))
            return;
        if (action === undefined)
            return;
        this.performer.remove(this.actions, action);
    }
    clearActionsT3() {
        this.actions = [];
    }
    actionT3(t1, t2, t3) {
        for (let action of this.actions)
            action.actionT3(t1, t2, t3);
    }
    actions = [];
}
exports.ActionArrayT3 = ActionArrayT3;
