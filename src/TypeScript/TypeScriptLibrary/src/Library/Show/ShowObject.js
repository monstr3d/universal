"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ShowObject = void 0;
const FactoryObject_1 = require("../FactoryObject");
const ActionArrayT_1 = require("../Utilities/Generic/ActionArrayT");
class ShowObject extends FactoryObject_1.FactoryObject {
    constructor(factory) {
        super("", factory);
        this.types.push("IShowObject");
        this.types.push("EmptyShowObject");
        this.typeName = "EmptyShowObject";
    }
    show(sender, show, name) {
        const data = { sender: sender, show: show, name: name };
        this.actionT(data);
        return true;
    }
    addActionT(action) {
        this.action.addActionT(action);
    }
    removeActionT(action) {
        this.action.removeActionT(action);
    }
    clearActionsT() {
        this.action.clearActionsT();
    }
    actionT(t) {
        this.action.actionT(t);
    }
    isEmptyActionT() {
        return this.action.isEmptyActionT();
    }
    object;
    str = undefined;
    action = new ActionArrayT_1.ActionArrayT();
}
exports.ShowObject = ShowObject;
