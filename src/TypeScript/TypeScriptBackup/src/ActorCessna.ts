import type { IGame } from "./Library/Game/Interfaces/IGame";
import type { IInput } from "./Library/Interfaces/IInput";
import type { IReferenceFrame } from "./Library/Motion6D/Interfaces/IReferenceFrame";
import type { IScadaConsumer } from "./Library/Scada/Interfaces/IScadaConsumer";
import type { IScadaInterface } from "./Library/Scada/Interfaces/IScadaInterface";
import type { IDataConsumer } from "./Library/Measurements/Interfaces/IDataConsumer";
import type { IMeasurement } from "./Library/Measurements/Interfaces/IMeasurement";
import { Game3DRealtime, getFactory } from "./Library/Abstract3DGame/Game3DRealtime";
import { Cessna } from "./scenes/Cessna";
import { AbstractAction } from "./Library/Event/Objects/AbstractAction";
import { AbstractActionT } from "./Library/Event/Objects/AbstractActionT";
import { TimerObject } from "./Library/Event/Objects/TimerObject";

export class ActorCessna extends Game3DRealtime {

    constructor() {
        super(getFactory(), new Cessna, 0.05, "Chart")
        let dataConsumer = this.scada.getScadaObject<IDataConsumer>("Chart", "IDataConsumer")[0]
        var mmm = dataConsumer.getAllMeasurements()
        var mm = mmm[2];
        this.X = mm.getMeasurement(3)
        this.Y = mm.getMeasurement(4)
        let sc = this.scene
        
        
           var ea = sc.getInternalAction()
            ea.addAction(new A("scene"));
            ea.addAction(new B(sc, this.game));
            var ena = this.game.getEngineAction()
            ena.addActionT(new TT())
            this.loadGame();
            for (let i = 0; i < 5000; i++) {
                this.actionT(i * 0.001)
            }
 }

    public getX(): number {
        let xx = this.X.getMeasurementValue()
        return 10 * Number(xx)
    }

    public getY(): number {
        let xx = this.Y.getMeasurementValue()
        return 10 * Number(xx)
    }

    vel: number = 0.005

    public setMotion(forward: boolean, backward: boolean, left: boolean, right: boolean, jump: boolean): void {
        let v = 0;
        if (forward) v = this.vel
        if (backward) v = -this.vel
        this.inputs[0].setInputValue("X", v)
     //   if (v != 0) console.log("X", v)
        v = 0
        if (left) v = this.vel
        if (right) v = -this.vel
        this.inputs[0].setInputValue("Y", v)
        //if (v != 0) console.log("Y", v)

    }



    X !: IMeasurement

    Y !: IMeasurement

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
    
    frame !: IReferenceFrame

    constructor(scene: IScadaConsumer, game: IGame) {
        super()
        this.game = game
        let scada = scene.getConsumerScada()
        this.inputs = scada.getScadaInputs()
        let dc = scada.getScadaObject<IDataConsumer>("Chart", "IDataConsumer")
        let f = scada.getScadaObject<IReferenceFrame>("Unity", "IReferenceFrame")

        this.frame = f[0]
        
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
        console.log(this.frame.getPosition())
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


