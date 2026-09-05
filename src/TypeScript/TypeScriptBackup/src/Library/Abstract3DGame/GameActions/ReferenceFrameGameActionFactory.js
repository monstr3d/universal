"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ReferenceFrameGameActionFactory = void 0;
const AbstractGameActionFactory_1 = require("../../Game/Abstract/AbstractGameActionFactory");
const ReferenceFrameGameAction_1 = require("./ReferenceFrameGameAction");
class ReferenceFrameGameActionFactory extends AbstractGameActionFactory_1.AbstractGameActionFactory {
    constructor(find, factory) {
        super(factory);
        this.typeName = "ReferenceFrameGameActionFactory";
        this.types.push("IGameAction");
        this.types.push("ReferenceFrameGameActionFactory");
        this.find = find;
    }
    functT(s) {
        this.s = s;
        return undefined;
    }
    getGameAction(object) {
        var sc = object;
        var fr = this.find.functT(sc);
        if (fr === undefined)
            return this;
        return new ReferenceFrameGameAction_1.ReferenceFrameGameAction(fr, "", this.getConsumerFactory());
    }
}
exports.ReferenceFrameGameActionFactory = ReferenceFrameGameActionFactory;
//# sourceMappingURL=ReferenceFrameGameActionFactory.js.map