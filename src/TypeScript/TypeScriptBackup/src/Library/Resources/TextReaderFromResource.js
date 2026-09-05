"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TextReaderFromResource = void 0;
const LinesTextReaderFromAny_1 = require("../IO/LinesTextReaderFromAny");
class TextReaderFromResource {
    constructor(items, func) {
        this.items = [];
        this.map = new Map();
        const f = func.functT('text');
        if (f === undefined)
            return;
        this.func = f;
        for (let r of items) {
            if (r.type == "text") {
                const url = r.url;
                const d = f.functT(url);
                this.map.set(url, d);
            }
        }
    }
    getTextReader(obj, url) {
        this.any = obj;
        return this.functT(url);
    }
    functT(url) {
        if (!this.map.has(url))
            return undefined;
        let r = this.map.get(url);
        if (r != undefined) {
            let any = this.func.functT(url);
            return new LinesTextReaderFromAny_1.LinesTextReaderFromAny(any);
        }
        return undefined;
    }
}
exports.TextReaderFromResource = TextReaderFromResource;
//# sourceMappingURL=TextReaderFromResource.js.map