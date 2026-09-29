import type { IComponentCollection } from "../Interfaces/IComponentCollection";
import type { IFactory } from "../Interfaces/IFactory";
import type { IPlayEngine } from "../Interfaces/IPlayEngine";
import type { IRealtimeCollectionFactory } from "../Interfaces/IRealtimeCollectionFactory";
import type { IDataConsumer } from "../Measurements/Interfaces/IDataConsumer";
import type { IActionAddRemove } from "../Interfaces/IActionAddRemove";
import type { IAction } from "../Interfaces/IAction";
import { EngineTimerProvider } from "../Event/Objects/EngineTimerProvider";
import { TimerPlayEngineFactory } from "../Event/TimerPlayEngineFactory";
import { ScadaDesktop } from "./ScadaDesktop";
import { ActionArray } from "../Utilities/Generic/ActionArray";


export class ScadaDesktopEngine extends ScadaDesktop
{
	constructor(componentCollection: IComponentCollection, engine:
		IPlayEngine, factory: IFactory, chart: string) {
        super(componentCollection);
        this.engine = engine;
        this.chart = chart;
        var f = factory.getFactory<IRealtimeCollectionFactory>("IRealtimeCollectionFactory");
        if (f === undefined) {
            return;
        }
        this.factory = f;
        this.uFactory = factory;
        this.createRuntime();
        engine.getEngineAction().addActionT(this)
    }

    public createRuntime(): void {
        let co = this.componentCollection.getCategoryObject(this.chart);
        let dc = co as unknown as IDataConsumer;
        let eev = this.factory.createRealtimeFromDataConsumer(dc, this.uFactory);
        let tp = new EngineTimerProvider(this.engine)
        eev.setTimeProvider(tp);
        eev.setTimerFactory(new TimerPlayEngineFactory(this.engine));
        this.runtime = eev;
    }

    addAction(action: IAction | undefined): void {
        this.actionr.addAction(action);
    }
    removeAction(action: IAction | undefined): void {
        this.actionr.removeAction(action);
    }
    clearActions(): void {
        this.actionr.clearActions()
    }
    action(): void {
        this.actionr.action();
    }
    isEmptyAction(): boolean {
        return this.actionr.isEmptyAction()
    }

    setScadaEnabled(enabled: boolean): void {
        super.setScadaEnabled(enabled)
        this.engine.setEngineEnabled(enabled)
    }


    actionr: IActionAddRemove = new ActionArray

    engine!: IPlayEngine;

    chart: string = "";

    factory!: IRealtimeCollectionFactory;

    uFactory!: IFactory;

}
