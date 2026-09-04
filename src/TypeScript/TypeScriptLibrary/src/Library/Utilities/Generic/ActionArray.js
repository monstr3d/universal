"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ActionArray = void 0;
const Performer_1 = require("../../Performer");
class ActionArray {
    isEmptyAction() {
        return this.actions.length == 0;
    }
    addAction(action) {
        if (this.performer.isEmptyAction(action))
            return;
        if (action === undefined)
            return;
        this.actions.push(action);
    }
    removeAction(action) {
        if (this.performer.isEmptyAction(action))
            return;
        if (action === undefined)
            return;
        this.performer.remove(this.actions, action);
    }
    clearActions() {
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
    action() {
        for (let action of this.actions)
            action.action();
    }
    addActionArray(actions) {
        for (let action of actions) {
            this.addAction(action);
        }
    }
    actions = [];
    typeName = "ActionArray";
    types = ["IAction", "IObject", "ActionArray"];
    performer = new Performer_1.Performer();
}
exports.ActionArray = ActionArray;
