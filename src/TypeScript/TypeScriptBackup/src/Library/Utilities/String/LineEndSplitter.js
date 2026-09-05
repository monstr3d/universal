"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.LineEndSplitter = void 0;
class LineEndSplitter {
    constructor() {
        this.typeName = "LineEndSplitter";
        this.types = ["IObject", "IStringSplitter", "LineEndSplitter"];
        this.name = "";
    }
    splitStrings(object, str) {
        this.object = object;
        return str.split('\n');
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
exports.LineEndSplitter = LineEndSplitter;
//# sourceMappingURL=LineEndSplitter.js.map