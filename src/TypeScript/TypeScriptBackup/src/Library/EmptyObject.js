"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EmptyObject = void 0;
const Performer_1 = require("./Performer");
class EmptyObject {
    constructor(name) {
        this.performer = new Performer_1.Performer();
        this.typeName = "EmptyObject";
        this.types = ["IObject", "EmptyObject"];
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
exports.EmptyObject = EmptyObject;
//# sourceMappingURL=EmptyObject.js.map