import type { IAction } from "../../Interfaces/IAction";
import type { IComponentCollection } from "../../Interfaces/IComponentCollection";
import type { IFactory } from "../../Interfaces/IFactory";
import type { IRealtimeCollectionFactory } from "../../Interfaces/IRealtimeCollectionFactory";
import type { IScadaInterface } from "../../Scada/Interfaces/IScadaInterface";
import type { IGameAction } from "../Interfaces/IGameAction";
import type { IGameActionFactory } from "../Interfaces/IGameActionFactory";
import type { ISceneObject } from "../Interfaces/ISceneObject";
import type { IScadaConsumer } from "../../Scada/Interfaces/IScadaConsumer";
import type { IPlayEngine } from "../../Interfaces/IPlayEngine";
import type { IObject } from "../../Interfaces/IObject";
import type { IActionT } from "../../Interfaces/IActionT";
import type { IInput } from "../../Interfaces/IInput";
import { AbstractGame } from "./AbstractGame";
import { EmptyObject } from "../../EmptyObject";
import { PerformerMeasuremets } from "../../Measurements/PerformerMeasuremets";
import { ScadaDesktop } from "../../Scada/ScadaDesktop";
import { ScadaDesktopEngine } from "../../Scada/ScadaDesktopEngine";
import { ExternalWatch } from "../../Utilities/Watch/ExternalWatch";
import { ActionArray } from "../../Utilities/Generic/ActionArray";


export abstract class AbstractScadaGame extends AbstractGame implements  IScadaConsumer,  IActionT<number>
{
    run(): void {
    }

    startItself(start: boolean): boolean {
        if (this.isStarted == start) return false
        this.isStarted = start
        this.scada.setScadaEnabled(start)
        this.performer.startCollecion(start, this);
        this.currentTime = Number.MAX_VALUE
        return true;
    }

    loadItself(load: boolean): boolean {
        return true
    }
    

    constructor(name: string, factory: IFactory | undefined, collection : IComponentCollection, chart: string, interval : number,
        engine?: IPlayEngine | undefined) {
        super(name, factory)
        let catO = collection.getCategoryObjects()
        catO.forEach((co) =>
        {
            let o = co as unknown as IObject
            this.objects.push(o)
        })
        this.chart = chart
        this.performerMeasurements = new PerformerMeasuremets(factory)
        this.types.push("AbstractScadaGame")
        this.types.push("IScadaConsumer")
        this.typeName = "AbstractScadaGame"
        this.collection = collection
        this.interval = interval
        if (engine === undefined)
        {
            this.engine = new ExternalWatch(interval, new ActionArray)

        }
        this.post(factory, collection)
        if (this.engine !== undefined) {
            this.scada = new ScadaDesktopEngine(collection, this.engine,
                this.factory, this.chart)
        }
        else {
            var eng = this.performer.convertObject<IPlayEngine, IObject>(this, "IPlayEngine")
            if (eng.length > 0) this.scada = new ScadaDesktopEngine(collection, eng[0],
                this.factory, this.chart)
            else this.scada = new ScadaDesktop(collection)
        }
        let inp = this.scada.getScadaInputs()
        inp.forEach((i) => {this.inputs.push(i) })
     }

    actionT(t: number): void {
        this.engine.actionT(t)
        this.externalAction.action()
    }

    isEmptyActionT(): boolean {
        return false
    }

    getConsumerScada(): IScadaInterface {
        return this.scada
    }

    setConsumerScada(scada: IScadaInterface): boolean {
        this.any = scada
        return false
    }

   

    protected  post(factory: IFactory | undefined, collection : IComponentCollection) : void
    {
         if (factory === undefined) return
        let f = factory
           f.addFactory<IGameActionFactory>(this.gaf, "IGameActionFactory")

    }

    protected scada !: IScadaInterface

    protected collection !: IComponentCollection

    protected gaf : IGameActionFactory = new GameActionFactory

    protected ealtimeFactory !: IRealtimeCollectionFactory

    protected performerMeasurements !: PerformerMeasuremets

    protected chart : string = ""

    protected currentTime: number = Number.MAX_VALUE

    protected interval : number = 0


    protected inputs: IInput[] = []


    protected engine !: ExternalWatch// ActionWatch = new ActionWatch(500, new ActionArray)


}

class GameActionFactory extends EmptyObject implements IGameActionFactory, IGameAction, IAction {
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
        this.any = s
        return this
    }

    getGameAction(object: any): IGameAction | undefined {
        this.any = object
        return this
    }

    any : any
}

