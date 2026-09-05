"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.LinesTextReaderFromAny = void 0;
const LinesTextReader_1 = require("./LinesTextReader");
class LinesTextReaderFromAny extends LinesTextReader_1.LinesTextReader {
    constructor(any) {
        super();
        let str = any;
        if (str != undefined) {
            this.text = str.replaceAll("\r\n", "\n");
            this.split();
            return;
        }
        let strs = any;
        if (strs.length == 1) {
            this.text = strs[0];
            this.split();
            return;
        }
        if (strs != undefined) {
            this.strings = strs;
            return;
        }
    }
}
exports.LinesTextReaderFromAny = LinesTextReaderFromAny;
//# sourceMappingURL=LinesTextReaderFromAny.js.map