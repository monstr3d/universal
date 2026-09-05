"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AirplaneScene = void 0;
const ScadaScene_1 = require("../src/Library/Game/Scenes/ScadaScene");
const Airplane_1 = require("./Airplane");
class AirplaneScene extends ScadaScene_1.ScadaScene {
    constructor(game, chart) {
        super(game, new Airplane_1.Airplane(), chart);
    }
}
exports.AirplaneScene = AirplaneScene;
//# sourceMappingURL=AirplaneScene.js.map