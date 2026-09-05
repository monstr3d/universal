"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.A = exports.Actor = void 0;
const AirplaneScene_1 = require("./scenes/AirplaneScene");
const FileGameFactory_1 = require("./src/Console/FileGameFactory");
const ReferenceFrameGameActionFactory_1 = require("./src/Library/Abstract3DGame/GameActions/ReferenceFrameGameActionFactory");
const ScadaFind3DFrame_1 = require("./src/Library/Abstract3DGame/GameActions/ScadaFind3DFrame");
const ScadaFindCamera_1 = require("./src/Library/Abstract3DGame/GameActions/ScadaFindCamera");
const AbstractAction_1 = require("./src/Library/Event/Objects/AbstractAction");
const AbstractActionT_1 = require("./src/Library/Event/Objects/AbstractActionT");
const EngineGame_1 = require("./src/Library/Game/Abstract/EngineGame");
const ActionArray_1 = require("./src/Library/Utilities/Generic/ActionArray");
const EngineWatch_1 = require("./src/Library/Utilities/Watch/EngineWatch");
const ExternalWatch_1 = require("./src/Library/Utilities/Watch/ExternalWatch");
const PIAct_1 = require("./test/wrappers/PIAct");
class Actor {
    //engine: FictiveEngine = new FictiveEngine()
    constructor(b) {
        this.dir = "C:\\AUsers\\1MySoft\\CSharp\\src\\TypeScript\\WebGLConsole/static/models";
        this.dir = this.dir.replaceAll("\\", "/");
        var find = new ScadaFind3DFrame_1.ScadaFind3dFrame("Camera");
        var ga = new ReferenceFrameGameActionFactory_1.ReferenceFrameGameActionFactory(find, undefined);
        var f = new FileGameFactory_1.FileGameFactory(this.dir, ga);
        ga.setConsumerFactory(f);
        this.factory = f;
        f.addFactory(find, "IFindFrame");
        f.addFactory(new ScadaFindCamera_1.ScadaFindCamera("Camera"), "IFindCamera");
        if (b) {
            let engine = new EngineWatch_1.EngineWatch(500);
            var g = new EngineGame_1.EngineGame("", this.factory, engine, false);
            g.getExternalAction().addAction(new A("game"));
            this.game = g;
            var sc = new AirplaneScene_1.AirplaneScene(this.game, "Chart");
            var ea = sc.getInternalAction();
            ea.addAction(new A("scene"));
            ea.addAction(new B(sc, g));
            var ena = g.getEngineAction();
            ena.addActionT(new TT());
            this.loadGame();
            return;
        }
        else {
            let engine = new ExternalWatch_1.ExternalWatch(0.5, new ActionArray_1.ActionArray);
            var g = new EngineGame_1.EngineGame("", this.factory, engine, false);
            g.getExternalAction().addAction(new A("game"));
            this.game = g;
            var sc = new AirplaneScene_1.AirplaneScene(this.game, "Chart");
            var ea = sc.getInternalAction();
            ea.addAction(new A("scene"));
            ea.addAction(new B(sc, g));
            var ena = g.getEngineAction();
            ena.addActionT(new TT());
            this.loadGame();
            for (let i = 0; i < 5000; i++) {
                engine.actionT(i * 0.001);
            }
        }
    }
    loadGame() {
        this.game.loadItself(true);
        this.game.startItself(true);
        /*for (let i = 0; i < 10; i++) {
              this.engine.setTime(i)
          }*/
    }
    actPI() {
        try {
            var o = new PIAct_1.PIAct();
            o.test();
        }
        catch (e) {
            //finish(e);
        }
    }
    actAirplane() {
    }
}
exports.Actor = Actor;
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
//# sourceMappingURL=Actor.js.map