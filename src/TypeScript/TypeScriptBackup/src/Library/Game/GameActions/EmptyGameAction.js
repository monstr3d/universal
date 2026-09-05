"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EmptyGameAction = void 0;
const AbstractGameAction_1 = require("../../Game/Abstract/AbstractGameAction");
class EmptyGameAction extends AbstractGameAction_1.AbstractGameAction {
    constructor(name, factory) {
        super(name, factory);
        this.typeName = "EmptyGameAction";
        this.types.push("EmptyGameAction");
    }
    action() {
    }
    isEmptyAction() {
        return false;
    }
    functT(s) {
        this.s = s;
        return this;
    }
}
exports.EmptyGameAction = EmptyGameAction;
//# sourceMappingURL=EmptyGameAction.js.map