import { stat } from "node:fs/promises";
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
import { IAction } from "./Library/Interfaces/IAction";
import { IActionT } from "./Library/Interfaces/IActionT";
import type { IFactory } from "./Library/Interfaces/IFactory";
import { IFunc } from "./Library/Interfaces/IFunc";
import type { IInput } from "./Library/Interfaces/IInput";
import type { IPlayEngine } from "./Library/Interfaces/IPlayEngine";
import type { IDataConsumer } from "./Library/Measurements/Interfaces/IDataConsumer";
import type { IScadaConsumer } from "./Library/Scada/Interfaces/IScadaConsumer";
import { IScadaInterface } from "./Library/Scada/Interfaces/IScadaInterface";
import { UniversalFactory } from "./Library/UniversalFactory";
import { ActionArray } from "./Library/Utilities/Generic/ActionArray";
import { ActionWatch } from "./Library/Utilities/Watch/ActionWatch";
import { ExternalWatch } from "./Library/Utilities/Watch/ExternalWatch";
import { AirplaneScene } from "./scenes/AirplaneScene";
import { IGameActionFactory } from "./Library/Game/Interfaces/IGameActionFactory";
import { IGameAction } from "./Library/Game/Interfaces/IGameAction";
import { EmptyObject } from "./Library/EmptyObject";
import { ISceneObject } from "./Library/Game/Interfaces/ISceneObject";
import { Motion6DRealtimeFactory } from "./Library/Motion6D/Runtime/Event/Motion6DRealtimeFactory";
import { DataRuntimeConsumerMotion6DEvent } from "./Library/Motion6D/Runtime/Event/DataRuntimeConsumerMotion6DEvent";
import { GameFactory } from "./GameFactory";
import { usePersonControls } from "./hooks";
import { exp } from "three/src/nodes/TSL.js";
import * as THREE from "three";
import { extend } from "@react-three/fiber";

class GA extends EmptyObject implements IGameActionFactory, IGameAction, IAction {
    constructor() {
        super("")
        this.types.push("IGameActionFactory")
        this.types.push("IGameAction")
        this.types.push("IAction")
        this.types.push("GA")       
    }
    action(): void {
    }
    isEmptyAction(): boolean {
        return true
    }
    functT(s: ISceneObject): IAction | undefined {
        return this
    }
    getGameAction(object: any): IGameAction | undefined {
        return this
    }
}
export class Actor implements IAction, IActionT<number>, IFunc<number> {

    factory!: IFactory;
    game!: IGame;

    inputs : IInput[] =[]


    engine !: ExternalWatch// ActionWatch = new ActionWatch(500, new ActionArray)

  //  url: string = "http://localhost:4173/static/models/pLANE/master.mtl"
    //engine: FictiveEngine = new FictiveEngine()
    constructor() {
        this.engine = new ExternalWatch(0.5, new ActionArray)
        //      this.dir = this.dir.replaceAll("\\", "/");
        var f = new GameFactory()
        f.addFactory(new GA(), "IGameActionFactory")
        this.factory = f;
        var g = new EngineGame("", this.factory, this.engine, false);
        // g.getExternalAction().addAction(new A("game"));
        this.game = g
        var sc = new AirplaneScene(this.game, "Chart");
        let scada = sc.getConsumerScada();
        let ii = scada.getScadaInputs()
        for (var i of ii) this.inputs.push(i)
      /*  var ea = sc.getInternalAction()
    /    ea.addAction(new Action(scada))
   /*     ea.addAction(new A("scene"));
        ea.addAction(new B(sc, g));
        var ena = g.getEngineAction()
        ena.addActionT(new TT())
        */
        this.loadGame()
    }

    func(): number {
        return (this.curr - this.start)
    }

    i: number = 0

    delta: number = 500

    curr: number = Number.MIN_VALUE

    last: number = Number.MAX_VALUE

    start: number = Number.MAX_VALUE

    public set(t: number, v : THREE.Vector3[]): void {
        this.actionT(t)
        this.inputs[0].setInputValue("x", this.x)
    //    console.log("X", this.x)
    }

    public setXYZ(x: number, y: number, z: number) : void {
        this.x = x
        this.y = y
        this.z = z
    //    console.log("XXX", x, y, z)
    }


    public setBollean(x: boolean): void {
       this.x = x ? 0.001 : -0.001
        //    console.log("XXX", x, y, z)
    }


    x: number = 0
    y: number = 0
    z : number = 0

    actionT(t: number): void {
   //     const { forward, backward, left, right, jump } = usePersonControls();

   //     let x = Number(forward) - Number(backward)
       // this.inputs[0].setInputValue("x", x)
        let time = t * 0.001
        this.engine.actionT(time)
    }

    isEmptyActionT(): boolean {
        return false
    }
    action(): void {
        this.engine.action()
    }
    isEmptyAction(): boolean {
        return false
    }

   

    public getEngine(): IPlayEngine {
        return this.engine
    }

    loadGame(): void {
        this.game.loadItself(true);
        this.game.startItself(true);
      /*for (let i = 0; i < 10; i++) {
            this.engine.setTime(i)
        }*/

    }

    public setMotion(forward: boolean, backward: boolean, left: boolean, right: boolean, jump: boolean): void {
        let v = 0;
        if (forward) v = 0.001
        if (backward) v = -0.01
        this.inputs[0].setInputValue("X", v)
        v = 0
        if (left) v = 0.001
        if (right) v = -0.01
        this.inputs[0].setInputValue("Y", v)

     }

}
class Action extends AbstractAction {
    action(): void {
        var mmm = this.dataConsumer.getAllMeasurements()
        var mm = mmm[0];
        var m = mm.getMeasurement(0)
        var v = m.getMeasurementValue()
        //  console.log("Value " + v)
        mm = mmm[2]
        m = mm.getMeasurement(3)
        let n = m.getMeasurementName();
        v = m.getMeasurementValue()
        console.log(n + " " + v)
        m = mm.getMeasurement(4)
        n = m.getMeasurementName();
        v = m.getMeasurementValue()
        console.log(n + " " + v)
    }
    dataConsumer !: IDataConsumer
    scada !: IScadaInterface
    
    constructor(scada: IScadaInterface) {
        super()
        {
            this.scada = scada
            this.dataConsumer = scada.getScadaObject<IDataConsumer>("Chart", "IDataConsumer")[0]

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
       // console.log(this.s + " " + this.i)
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
      //  console.log("Value " + v)
        mm = mmm[2]
        m = mm.getMeasurement(3)
        let n = m.getMeasurementName();
        v = m.getMeasurementValue()
        console.log(n + " " + v)
    }
}

class TT extends AbstractActionT<number> {
    actionT(t: number): void {
       // console.log("2 * time " + 2 * t)
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
        //console.log("time " + t)
        if (t > 2) {
           // console.log("FORCE")
           // this.inputs[0].setInputValue("X", 1)
        }
        if (t > 5) {
          //  this.game.startItself(false)
        }
    }
}




