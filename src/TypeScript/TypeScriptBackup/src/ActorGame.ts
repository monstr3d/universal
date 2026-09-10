import { Airplane } from "../scenes/Airplane";
import { Cessna } from "../Cessna";
import { IMtlDetector } from "./Library/Abstract3DConverters/Interfaces/IMtlDetector";
import { BasicGameLoaderFactory } from "./Library/Abstract3DGame/Factory/BacicGameLoaderFactory";
import { Game3DRealtime, getFactory } from "./Library/Abstract3DGame/Game3DRealtime";
import { EmptyObject } from "./Library/EmptyObject";
import { AbstractAction } from "./Library/Event/Objects/AbstractAction";
import { AbstractActionT } from "./Library/Event/Objects/AbstractActionT";
import { TimerObject } from "./Library/Event/Objects/TimerObject";
import { IGame } from "./Library/Game/Interfaces/IGame";
import { IGameAction } from "./Library/Game/Interfaces/IGameAction";
import { IGameActionFactory } from "./Library/Game/Interfaces/IGameActionFactory";
import { IGameLoaderFactory } from "./Library/Game/Interfaces/IGameLoaderFactory";
import { ISceneObject } from "./Library/Game/Interfaces/ISceneObject";
import { IAction } from "./Library/Interfaces/IAction";
import { IFactory } from "./Library/Interfaces/IFactory";
import { IInput } from "./Library/Interfaces/IInput";
import { IDataConsumer } from "./Library/Measurements/Interfaces/IDataConsumer";
import { ResourceFuncFactory } from "./Library/Resources/ResourceFuncFactory";
import { IScadaConsumer } from "./Library/Scada/Interfaces/IScadaConsumer";
import { IScadaInterface } from "./Library/Scada/Interfaces/IScadaInterface";
import { UniversalFactory } from "./Library/UniversalFactory";
import { IStringSplitter } from "./Library/Utilities/String/Interfaces/IStringSplitter";
import { LineEndSplitter } from "./Library/Utilities/String/LineEndSplitter";

export class ActorGame extends Game3DRealtime {

    constructor() {
        super(getFactory(), new Cessna, 0.5, "Chart")
        this.game.getExternalAction().addAction(new A("game"));
        var ea = this.scene.getInternalAction()
        ea.addAction(new A("scene"));
        ea.addAction(new B(this.scene, this.game));
        var ena = this.game.getEngineAction()
        ena.addActionT(new TT())
        this.loadGame()
        for (var i = 0; i < 1000; i++) {
            let t = i * i * 0.01
            this.actionT(t)
        }
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

    constructor(game: IGame, inputs: IInput[]
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

