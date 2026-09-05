"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractSceneGameAction = void 0;
const AbstractGameObject_1 = require("../Abstract/AbstractGameObject");
class AbstractSceneGameAction extends AbstractGameObject_1.AbstractGameObject {
    constructor(object, factory) {
        super("", factory);
        this.typeName = "AbstractSceneGameAction";
        this.types.push("ISceneObjectAction");
        this.types.push("IAction");
        this.types.push("AbstractSceneGameAction");
        this.object = object;
    }
    getActionSceneObject() {
        return this.object;
    }
    isEmptyAction() {
        return false;
    }
}
exports.AbstractSceneGameAction = AbstractSceneGameAction;
//# sourceMappingURL=AbstractSceneGameAction.js.map