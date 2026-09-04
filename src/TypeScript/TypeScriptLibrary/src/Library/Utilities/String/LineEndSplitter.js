"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.LineEndSplitter = void 0;
class LineEndSplitter {
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
    typeName = "LineEndSplitter";
    types = ["IObject", "IStringSplitter", "LineEndSplitter"];
    name = "";
    object;
}
exports.LineEndSplitter = LineEndSplitter;
