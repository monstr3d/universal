"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EmptyAction = void 0;
const AbstractAction_1 = require("./AbstractAction");
class EmptyAction extends AbstractAction_1.AbstractAction {
    constructor() {
        super();
        this.typeName = "EmptyAction";
        this.types.push("EmptyAction");
    }
    action() {
    }
    isEmptyAction() {
        return true;
    }
}
exports.EmptyAction = EmptyAction;
//# sourceMappingURL=EmptyAcion.js.map