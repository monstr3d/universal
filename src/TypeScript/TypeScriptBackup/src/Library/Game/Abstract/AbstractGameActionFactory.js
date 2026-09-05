"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractGameActionFactory = void 0;
const FactoryObject_1 = require("../../FactoryObject");
class AbstractGameActionFactory extends FactoryObject_1.FactoryObject {
    constructor(factory) {
        super("", factory);
        this.types.push("IGameActionFactory");
        this.types.push("AbstractGameActionFactory");
        this.typeName = "AbstractGameActionFactory";
    }
}
exports.AbstractGameActionFactory = AbstractGameActionFactory;
//# sourceMappingURL=AbstractGameActionFactory.js.map