"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EmptyGame3DObject = void 0;
const Game3DPerformer_1 = require("./Game3DPerformer");
class EmptyGame3DObject {
    constructor(name) {
        this.performer = new Game3DPerformer_1.Game3DPerformer();
        this.typeName = "EmptyGameObject";
        this.types = ["IObject", "EmptyGame3DObject"];
        this.name = "";
        this.name = name;
    }
    getName() {
        return this.name;
    }
    getClassName() {
        return this.typeName;
    }
    imlplementsType(type) {
        return this.types.includes(type);
    }
}
exports.EmptyGame3DObject = EmptyGame3DObject;
//# sourceMappingURL=EmptyGame3DObject.js.map