"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ScenePerformer = void 0;
const GamePerformer_1 = require("./GamePerformer");
const SceneObjectAction_1 = require("./SceneObjectAction.");
class ScenePerformer extends GamePerformer_1.GamePerformer {
    constructor(scene) {
        super();
        this.scene = scene;
        this.factory = scene.getConsumerFactory();
    }
    createSceneAction() {
        var s = this.scene;
        var act = new SceneObjectAction_1.SceneObjectAction(s);
        this.forEach(s, act, "ISceneObject");
    }
}
exports.ScenePerformer = ScenePerformer;
//# sourceMappingURL=ScenePerformer.js.map