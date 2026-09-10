"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.A = exports.ActorGame = void 0;
const Cessna_1 = require("../Cessna");
const Game3DRealtime_1 = require("./Library/Abstract3DGame/Game3DRealtime");
const AbstractAction_1 = require("./Library/Event/Objects/AbstractAction");
const AbstractActionT_1 = require("./Library/Event/Objects/AbstractActionT");
class ActorGame extends Game3DRealtime_1.Game3DRealtime {
    constructor() {
        super((0, Game3DRealtime_1.getFactory)(), new Cessna_1.Cessna, 0.5, "Chart");
        this.game.getExternalAction().addAction(new A("game"));
        var ea = this.scene.getInternalAction();
        ea.addAction(new A("scene"));
        ea.addAction(new B(this.scene, this.game));
        var ena = this.game.getEngineAction();
        ena.addActionT(new TT());
        this.loadGame();
        for (var i = 0; i < 1000; i++) {
            let t = i * i * 0.01;
            this.actionT(t);
        }
    }
}
exports.ActorGame = ActorGame;
class A extends AbstractAction_1.AbstractAction {
    constructor(s) {
        super();
        this.s = "";
        this.i = 0;
        this.s = s;
    }
    action() {
        ++this.i;
        console.log(this.s + " " + this.i);
    }
}
exports.A = A;
class B extends AbstractAction_1.AbstractAction {
    constructor(scene, game) {
        super();
        this.game = game;
        let scada = scene.getConsumerScada();
        this.inputs = scada.getScadaInputs();
        let dc = scada.getScadaObject("Chart", "IDataConsumer");
        this.dataConsumer = dc[0];
        let timer = scada.getScadaObject("Timer", "TimerObject");
        timer[0].eventActionT().addActionT(new TA(this.game, this.inputs));
    }
    action() {
        var mmm = this.dataConsumer.getAllMeasurements();
        var mm = mmm[0];
        var m = mm.getMeasurement(0);
        var v = m.getMeasurementValue();
        console.log("Value " + v);
        mm = mmm[2];
        m = mm.getMeasurement(3);
        let n = m.getMeasurementName();
        v = m.getMeasurementValue();
        console.log(n + " " + v);
    }
}
class TT extends AbstractActionT_1.AbstractActionT {
    actionT(t) {
        console.log("2 * time " + 2 * t);
    }
}
class TA extends AbstractActionT_1.AbstractActionT {
    constructor(game, inputs) {
        super();
        this.game = game;
        this.inputs = inputs;
    }
    actionT(t) {
        console.log("time " + t);
        if (t > 2) {
            console.log("FORCE");
            this.inputs[0].setInputValue("X", 1);
        }
        if (t > 5) {
            this.game.startItself(false);
        }
    }
}
//# sourceMappingURL=ActorGame.js.map