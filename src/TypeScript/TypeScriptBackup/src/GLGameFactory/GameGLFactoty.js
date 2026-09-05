"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.GameGLFactory = void 0;
const BacicGameLoaderFactory_1 = require("../Library/Abstract3DGame/Factory/BacicGameLoaderFactory");
const Motion6DFactory_1 = require("../Library/Motion6D/Motion6DFactory");
const LineEndSplitter_1 = require("../Library/Utilities/String/LineEndSplitter");
class GameGLFactory extends Motion6DFactory_1.Motion6DFactory {
    constructor(gameActionFactory) {
        super();
        this.addFactory(new BacicGameLoaderFactory_1.BasicGameLoaderFactory(), "IGameLoaderFactory");
        //this.addFactory<IMtlDetector>(mtl, "IMtlDetector")
        this.addFactory(new LineEndSplitter_1.LineEndSplitter(), "IStringSplitter");
        this.addFactory(gameActionFactory, "IGameActionFactory");
    }
}
exports.GameGLFactory = GameGLFactory;
//# sourceMappingURL=GameGLFactoty.js.map