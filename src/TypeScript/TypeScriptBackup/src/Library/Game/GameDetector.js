"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.GameDetector = void 0;
const FactoryObject_1 = require("../FactoryObject");
class GameDetector extends FactoryObject_1.FactoryObject {
    detectGame() {
        return this.game;
    }
    constructor(game, factory) {
        super("", factory);
        this.types.push("IGameDetector");
        this.types.push("GameDetector");
        this.typeName = "GameDetector";
        this.game = game;
    }
}
exports.GameDetector = GameDetector;
//# sourceMappingURL=GameDetector.js.map