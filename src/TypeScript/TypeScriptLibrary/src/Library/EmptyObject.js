"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EmptyObject = void 0;
const Performer_1 = require("./Performer");
class EmptyObject {
    performer = new Performer_1.Performer();
    constructor(name) {
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
    typeName = "EmptyObject";
    types = ["IObject", "EmptyObject"];
    name = "";
}
exports.EmptyObject = EmptyObject;
