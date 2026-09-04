"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.UniversalFactory = void 0;
const OwnError_1 = require("./ErrorHandler/OwnError");
const FactoryObject_1 = require("./FactoryObject");
class UniversalFactory extends FactoryObject_1.FactoryObject {
    constructor() {
        super("", undefined);
        this.factory = this;
        this.types.push("IFactory");
        this.types.push("UniversalFactory");
        this.typeName = "UniversalFactory";
    }
    removeFactory(t, type) {
        let x = this.factories.get(type);
        if (x != t)
            throw new OwnError_1.OwnError("Illegal delete factory", "", "");
        this.factories.delete(type);
    }
    getFactory(typeName) {
        var p = this.factories.get(typeName);
        var pp = this.performer.convertObject(p, typeName);
        return (pp.length == 0) ? undefined : pp[0];
    }
    addFactory(t, type) {
        if (this.factories.has(type))
            throw new OwnError_1.OwnError("Factory", type, "aleady exists");
        var tt = this.performer.convertObject(t, type);
        if (tt.length > 0)
            this.factories.set(type, tt[0]);
        else
            console.log("FAIL ", type);
    }
    factories = new Map();
}
exports.UniversalFactory = UniversalFactory;
