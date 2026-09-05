"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractGameAction = void 0;
const AbstractGameObject_1 = require("./AbstractGameObject");
class AbstractGameAction extends AbstractGameObject_1.AbstractGameObject {
    constructor(name, factory) {
        super(name, factory);
        this.types.push("IGameAction");
        this.types.push("AbstractGameAction");
        this.typeName = "AbstractGameAction";
    }
}
exports.AbstractGameAction = AbstractGameAction;
//# sourceMappingURL=AbstractGameAction.js.map