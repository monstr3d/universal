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
import { IMeasurement } from "./Library/Measurements/Interfaces/IMeasurement";
import { Game3DRealtimeReactGL } from "./ReactWebGL/Game3DRealtimeReactGL";
import { Airplane } from "./scenes/Airplane";
import { Game3DRealtime, getFactory } from "./Library/Abstract3DGame/Game3DRealtime";
import { Cessna } from "./scenes/Cessna";
import { ScadaScene } from "./Library/Game/Scenes/ScadaScene";

export class Actor extends Game3DRealtimeReactGL {

    constructor() {
        super(getFactory(), new Cessna, 0.5, "Chart")
        let dataConsumer = this.scada.getScadaObject<IDataConsumer>("Chart", "IDataConsumer")[0]
        var mmm = dataConsumer.getAllMeasurements()
        var mm = mmm[2];
        this.X = mm.getMeasurement(3)
        this.Y = mm.getMeasurement(4)
        this.loadGame()

    }


    public getX(): number {
        let xx = this.X.getMeasurementValue()
        return 10 * Number(xx)
    }

    public getY(): number {
        let xx = this.Y.getMeasurementValue()
        return 10 * Number(xx)
    }


    public setMotion(forward: boolean, backward: boolean, left: boolean, right: boolean, jump: boolean): void {
        let v = 0;
        if (forward) v = 0.001
        if (backward) v = -0.001
        this.inputs[0].setInputValue("X", v)
     //   if (v != 0) console.log("X", v)
        v = 0
        if (left) v = 0.001
        if (right) v = -0.001
        this.inputs[0].setInputValue("Y", v)
      //  if (v != 0) console.log("Y", v)

    }



    X !: IMeasurement

    Y !: IMeasurement

}




export class Actor1 implements IAction, IActionT<number>, IFunc<number> {

    factory!: IFactory;
    game!: IGame;

    inputs: IInput[] = []

    X !: IMeasurement

    Y !: IMeasurement


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
        var sc = new ScadaScene(this.game, new Cessna, "Chart");
        let scada = sc.getConsumerScada();
        let ii = scada.getScadaInputs()
        for (var i of ii) this.inputs.push(i)
        var ea = sc.getInternalAction()
   /*     ea.addAction(new A("scene"));
        ea.addAction(new B(sc, g));
        var ena = g.getEngineAction()
        ena.addActionT(new TT())
        */
        let dataConsumer = scada.getScadaObject<IDataConsumer>("Chart", "IDataConsumer")[0]
        var mmm = dataConsumer.getAllMeasurements()
        console.log(mmm)
        var mm = mmm[2];
        this.X = mm.getMeasurement(3)
        this.Y = mm.getMeasurement(4)
        this.loadGame()
    }

    public getX(): number {
        let xx = this.X.getMeasurementValue()
        return 10 * Number(xx)
    }

    public getY(): number {
        let xx = this.Y.getMeasurementValue()
        return 10 * Number(xx)
    }


    func(): number {
        return (this.curr - this.start)
    }

    i: number = 0

    delta: number = 500

    curr: number = Number.MIN_VALUE

    last: number = Number.MAX_VALUE

    start: number = Number.MAX_VALUE


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
        this.engine.actionT(t)
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
        if (backward) v = -0.001
        this.inputs[0].setInputValue("X", v)
        if (v != 0) console.log("X", v)
        v = 0
        if (left) v = 0.001
        if (right) v = -0.001
        this.inputs[0].setInputValue("Y", v)
        if (v != 0) console.log("Y", v)

     }
}

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