"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractGameAcionConverter = void 0;
const AbstractGameObject_1 = require("../Abstract/AbstractGameObject");
class AbstractGameAcionConverter extends AbstractGameObject_1.AbstractGameObject {
    constructor() {
        super("", undefined);
        this.typeName = "AbstractGameAcionConverter";
        this.types.push("IGameAcionConverter");
        this.types.push("AbstractGameAcionConverter");
    }
}
exports.AbstractGameAcionConverter = AbstractGameAcionConverter;
//# sourceMappingURL=AbstractGameAcionConverter.js.map