"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.BasicGameLoaderFactory = void 0;
const AbstractGameLoaderFactory_1 = require("../../Game/Abstract/AbstractGameLoaderFactory");
const Object3DLoader_1 = require("./Object3DLoader");
class BasicGameLoaderFactory extends AbstractGameLoaderFactory_1.AbstractGameLoaderFactory {
    constructor() {
        super();
        this.typeName = "BasicGameLoaderFactory";
        this.types.push("BasicGameLoaderFactory");
    }
    getLoader(object) {
        this.current = object;
        return new Object3DLoader_1.Object3DLoader();
    }
}
exports.BasicGameLoaderFactory = BasicGameLoaderFactory;
//# sourceMappingURL=BacicGameLoaderFactory.js.map