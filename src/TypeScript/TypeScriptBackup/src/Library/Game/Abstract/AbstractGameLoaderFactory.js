"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractGameLoaderFactory = void 0;
class AbstractGameLoaderFactory {
    constructor() {
        this.typeName = "AbstracGameLoaderFactory";
        this.types = ["IObject", "IGameLoaderFactory", "AbstracGameLoaderFactory"];
        this.name = "";
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
exports.AbstractGameLoaderFactory = AbstractGameLoaderFactory;
//# sourceMappingURL=AbstractGameLoaderFactory.js.map