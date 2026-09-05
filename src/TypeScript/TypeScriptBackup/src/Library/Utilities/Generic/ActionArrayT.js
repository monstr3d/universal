"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ActionArrayT = void 0;
const Performer_1 = require("../../Performer");
class ActionArrayT {
    constructor() {
        this.actions = [];
        this.typeName = "ActionArrayT";
        this.types = ["IActionT", "IActionArrayT", "IObject", "ActionArrayT"];
        this.performer = new Performer_1.Performer();
    }
    isEmptyActionT() {
        return this.actions.length == 0;
    }
    addActionT(action) {
        if (this.performer.isEmptyActionT(action))
            return;
        if (action === undefined)
            return;
        this.actions.push(action);
    }
    removeActionT(action) {
        if (this.performer.isEmptyActionT(action))
            return;
        if (action === undefined)
            return;
        this.performer.remove(this.actions, action);
    }
    clearActionsT() {
        this.actions = [];
    }
    getClassName() {
        return this.typeName;
    }
    imlplementsType(type) {
        return this.types.indexOf(type) > 0;
    }
    getName() {
        return "";
    }
    actionT(t) {
        for (let action of this.actions)
            action.actionT(t);
    }
}
exports.ActionArrayT = ActionArrayT;
//# sourceMappingURL=ActionArrayT.js.map