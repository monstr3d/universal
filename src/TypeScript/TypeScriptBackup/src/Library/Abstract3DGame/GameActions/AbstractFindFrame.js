"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractFindFrame = void 0;
const EmptyObject_1 = require("../../EmptyObject");
const GamePerformer_1 = require("../../Game/GamePerformer");
class AbstractFindFrame extends EmptyObject_1.EmptyObject {
    constructor(name) {
        super(name);
        this.performer = new GamePerformer_1.GamePerformer();
        this.types.push("IFindFrame");
        this.types.push("AbstractFindFrame");
        this.typeName = "AbstractFindFrame";
    }
}
exports.AbstractFindFrame = AbstractFindFrame;
//# sourceMappingURL=AbstractFindFrame.js.map