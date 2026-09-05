import { ReferenceFrameGameActionFactory } from "./Library/Abstract3DGame/GameActions/ReferenceFrameGameActionFactory";
import { ScadaFind3dFrame } from "./Library/Abstract3DGame/GameActions/ScadaFind3DFrame";
import { ScadaFindCamera } from "./Library/Abstract3DGame/GameActions/ScadaFindCamera";
import type { IFindCamera } from "./Library/Abstract3DGame/Interfaces/IFindCamera";
import type { IFindFrame } from "./Library/Abstract3DGame/Interfaces/IFindFrame";
import { AbstractAction } from "./Library/Event/Objects/AbstractAction";
import { AbstractActionT } from "./Library/Event/Objects/AbstractActionT";
import { TimerObject } from "./Library/Event/Objects/TimerObject";
import { EngineGame } from "./Library/Game/Abstract/EngineGame";
import type { IGame } from "./Library/Game/Interfaces/IGame";
import type { IFactory } from "./Library/Interfaces/IFactory";
import type { IInput } from "./Library/Interfaces/IInput";
import type { IDataConsumer } from "./Library/Measurements/Interfaces/IDataConsumer";
import type { IScadaConsumer } from "./Library/Scada/Interfaces/IScadaConsumer";
import { IScadaInterface } from "./Library/Scada/Interfaces/IScadaInterface";
import { UniversalFactory } from "./Library/UniversalFactory";
import  { EngineWatch } from "./Library/Utilities/Watch/EnfineWatch";
import { AirplaneScene } from "./scenes/AirplaneScene";



export class Actor {

    factory!: IFactory;
    game!: IGame;

    url: string = "http://localhost:4173/static/models/pLANE/master.mtl"
    //engine: FictiveEngine = new FictiveEngine()
    constructor() {
        this.dir = this.dir.replaceAll("\\", "/");
        var find = new ScadaFind3dFrame("Camera");
        var ga = new ReferenceFrameGameActionFactory(find, undefined);
        var f = new UniversalFactory()
        ga.setConsumerFactory(f)
        this.factory = f;
        f.addFactory<IFindFrame>(find, "IFindFrame")
        f.addFactory<IFindCamera>(new ScadaFindCamera("Camera"), "IFindCamera")
        let engine = new EngineWatch(500)
        var g = new EngineGame("", this.factory, engine, false);
        g.getExternalAction().addAction(new A("game"));
        this.game = g;
        var sc = new AirplaneScene(this.game, "Chart");
        let scada = sc.getConsumerScada();
       /* var ea = sc.getInternalAction()
        ea.addAction(new A("scene"));
        ea.addAction(new B(sc, g));
        var ena = g.getEngineAction()
        ena.addActionT(new TT())*/
    
    }

    loadGame(): void {
        this.game.loadItself(true);
        this.game.startItself(true);
      /*for (let i = 0; i < 10; i++) {
            this.engine.setTime(i)
        }*/

    }


    dir: string = "C:\\AUsers\\1MySoft\\CSharp\\src\\TypeScript\\WebGLConsole/static/models";
    actPI(): void {
        try {
            var o = new PIAct();
            o.test();
        }
        catch (e) {
            //finish(e);
        }
    }

    actAirplane(): void {
    }

}

export class A extends AbstractAction {
    s: string = ""
    i: number = 0
    constructor(s: string) {
        super()
        this.s = s;
    }
    action(): void {
        ++this.i
        console.log(this.s + " " + this.i)
    }

}

class B extends AbstractAction {

    game !: IGame
    dataConsumer !: IDataConsumer
    scada !: IScadaInterface

    inputs !: IInput[] 
    constructor(scene: IScadaConsumer, game: IGame) {
        super()
        this.game = game
        let scada = scene.getConsumerScada()
        this.inputs = scada.getScadaInputs()
        let dc = scada.getScadaObject<IDataConsumer>("Chart", "IDataConsumer")
        this.dataConsumer = dc[0];
        let timer = scada.getScadaObject<TimerObject>("Timer", "TimerObject")
        timer[0].eventActionT().addActionT(new TA(this.game, this.inputs))
    }

    action(): void {
        var mmm = this.dataConsumer.getAllMeasurements()
        var mm = mmm[0];
        var m = mm.getMeasurement(0)
        var v = m.getMeasurementValue()
        console.log("Value " + v)
        mm = mmm[2]
        m = mm.getMeasurement(3)
        let n = m.getMeasurementName();
        v = m.getMeasurementValue()
        console.log(n + " " + v)
    }
}

class TT extends AbstractActionT<number> {
    actionT(t: number): void {
        console.log("2 * time " + 2 * t)
    }

}

class TA extends AbstractActionT<number> {
    game !: IGame
    inputs !: IInput[] 

    constructor(game: IGame, inputs : IInput[]
) {
        super()
        this.game = game
        this.inputs = inputs
    }
    actionT(t: number): void {
        console.log("time " + t)
        if (t > 2) {
            console.log("FORCE")
            this.inputs[0].setInputValue("X", 1)
        }
        if (t > 5) {
            this.game.startItself(false)
        }
    }
}



