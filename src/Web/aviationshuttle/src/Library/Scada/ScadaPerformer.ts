import type { IActionAddRemove } from "../Interfaces/IActionAddRemove";
import type { IActionT } from "../Interfaces/IActionT";
import type { IComponentCollection } from "../Interfaces/IComponentCollection";
import type { IFactory } from "../Interfaces/IFactory";
import type { IObjectCollection } from "../Interfaces/IObjectCollection";
import type { IScadaConsumer } from "./Interfaces/IScadaConsumer";
import type { IScadaInterface } from "./Interfaces/IScadaInterface";
import type { IPlayEngine } from "../Interfaces/IPlayEngine";
import { Performer } from "../Performer";
import { ScadaDesktopEngine } from "./ScadaDesktopEngine";
import { ActionWatch } from "../Utilities/Watch/ActionWatch";

export class ScadaPerformer extends Performer implements IActionT<IScadaConsumer>
{
    public setScada(collection: IObjectCollection, scada: IScadaInterface): void {
        this.scada = scada
        this.forEach<IScadaConsumer>(collection, this, "IScadaConsumer")
    }


    actionT(t: IScadaConsumer): void {
        t.setConsumerScada(this.scada);
    }

	isEmptyActionT(): boolean { return false }

    public createScadaDesktopEngine(componentCollection: IComponentCollection,
        engine: IPlayEngine, factory: IFactory, chart: string): IActionAddRemove
    {
        return new ScadaDesktopEngine(componentCollection, engine, factory, chart)
    }

    public createScadaDesktopAction(componentCollection: IComponentCollection,
        action: IActionAddRemove, interval: number, factory: IFactory, chart: string): IActionAddRemove {
        let engine = new ActionWatch(interval, action)
        return new ScadaDesktopEngine(componentCollection, engine, factory, chart)
    }



    scada !: IScadaInterface;

}
