"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.LinesTextReader = void 0;
const EmptyObject_1 = require("../EmptyObject");
class LinesTextReader extends EmptyObject_1.EmptyObject {
    constructor() {
        super("");
        this.types.push("ITextReader");
        this.types.push("EmptyObject");
        this.typeName = "EmptyObject";
    }
    getStrings() {
        return this.strings;
    }
    reset() {
        this.n = 0;
        this.end = false;
    }
    readToEnd() {
        this.end = true;
        return this.text;
    }
    readLine() {
        let s = this.strings[this.n];
        this.n++;
        if (this.n >= this.strings.length)
            this.end = true;
        return s;
    }
    eof() {
        return this.end;
    }
    split() {
        var s = this.text.split("\n");
        for (var str of s) {
            this.strings.push(str.replace("\r", ""));
        }
    }
    typeName = "LinesTextReader";
    types = ["IObject", "ITextReader", "LinesTextReader"];
    name = "";
    strings = [];
    text = "";
    end = false;
    n = 0;
}
exports.LinesTextReader = LinesTextReader;
