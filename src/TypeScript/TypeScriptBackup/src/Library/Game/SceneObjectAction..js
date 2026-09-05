"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SceneObjectAction = void 0;
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
const GamePerformer_1 = require("./GamePerformer");
class SceneObjectAction {
    actionT(t) {
        var a = this.gameAcion.functT(t);
        if (this.conv != undefined) {
            if (a != undefined) {
                var b = this.conv.functT(a);
                this.action.addAction(b);
                return;
            }
        }
        this.action.addAction(a);
    }
    constructor(scene) {
        this.performer = new GamePerformer_1.GamePerformer();
        this.scene = scene;
        var f = scene.getConsumerFactory();
        var ff = f.getFactory("IGameActionFactory");
        var a = ff?.getGameAction(scene);
        if (a != undefined) {
            this.gameAcion = a;
        }
        else {
            throw new OwnNotImplemented_1.OwnNotImplemented("SCENE OBJECT ACTION");
        }
        var conv = f.getFactory("IGameActionConverter");
        if (conv != undefined) {
            this.conv = conv;
        }
        var fc = f.getFactory("IGameActionConverterFactory");
        if (fc != undefined) {
            var conv = fc.getGameActionConverter(scene);
            if (conv != undefined) {
                this.conv = conv;
            }
        }
        this.action = scene.getInternalAction();
    }
    isEmptyActionT() {
        return false;
    }
}
exports.SceneObjectAction = SceneObjectAction;
//# sourceMappingURL=SceneObjectAction..js.map