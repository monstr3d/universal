"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PurePathFactory = void 0;
const PurePath_1 = require("./PurePath");
class PurePathFactory {
    constructor() {
        this.typeName = "PurePathFactory";
        this.types = ["IObject", "IPathFactory", "PurePathFactory"];
        this.name = "";
    }
    createPath(obj) {
        this.any = obj;
        return new PurePath_1.PurePath();
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
exports.PurePathFactory = PurePathFactory;
//# sourceMappingURL=PurePathFactory.js.map