"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ActorGameImmelman = void 0;
const Game3DRealtime_1 = require("./Library/Abstract3DGame/Game3DRealtime");
const Immelman_1 = require("./scenes/Immelman");
class ActorGameImmelman extends Game3DRealtime_1.Game3DRealtime {
    constructor() {
        super((0, Game3DRealtime_1.getFactory)(), new Immelman_1.Immelman, 0.5, "Consumer");
        this.loadGame();
        for (var i = 0; i < 1000; i++) {
            let t = i * i * 0.01;
            this.actionT(t);
        }
    }
}
exports.ActorGameImmelman = ActorGameImmelman;
//# sourceMappingURL=ActorGameImmelman.js.map