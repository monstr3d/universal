"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ConverterTextReadertFactory = void 0;
class ConverterTextReadertFactory {
    constructor(factory, func) {
        this.factory = factory;
        this.func = func;
    }
    getTextReader(obj, url) {
        let str = this.func.functT(url);
        if (str == undefined)
            return undefined;
        return this.factory.getTextReader(obj, str);
    }
    factory;
    func;
    any;
}
exports.ConverterTextReadertFactory = ConverterTextReadertFactory;
