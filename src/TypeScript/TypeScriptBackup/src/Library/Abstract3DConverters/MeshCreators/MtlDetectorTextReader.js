"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.MtlDetectorTextReader = void 0;
class MtlDetectorTextReader {
    constructor(factory) {
        this.typeName = "MtlDetectorTextReader";
        this.types = ["IObject", "IMtlDetector", "MtlDetectorTextReader"];
        this.name = "";
        this.factory = factory;
    }
    detectMtl(url, obj) {
        var reader = this.factory.getTextReader(obj, url);
        if (reader === undefined)
            return [];
        return reader.getStrings();
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
exports.MtlDetectorTextReader = MtlDetectorTextReader;
//# sourceMappingURL=MtlDetectorTextReader.js.map