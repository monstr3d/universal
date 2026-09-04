"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ResourceFuncFactory = void 0;
const FactoryObject_1 = require("../FactoryObject");
class ResourceFuncFactory extends FactoryObject_1.FactoryObject {
    constructor(name, factory) {
        super(name, factory);
        this.types.push("IResourceFuncFactory");
        this.types.push("ResourceFuncFactory");
        this.typeName = "ResourceFuncFactory";
    }
    addFunction(type, func) {
        if (this.map.has(type))
            return false;
        this.map.set(type, func);
        return true;
    }
    functT(s) {
        if (this.map.has(s))
            return this.map.get(s);
        return undefined;
    }
    map = new Map();
}
exports.ResourceFuncFactory = ResourceFuncFactory;
