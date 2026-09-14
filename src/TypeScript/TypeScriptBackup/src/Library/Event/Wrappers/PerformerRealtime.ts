import type { IComponentCollection } from "../../Interfaces/IComponentCollection";
import type { IDesktop } from "../../Interfaces/IDesktop";
import type { IFactory } from "../../Interfaces/IFactory";
import type { IInput } from "../../Interfaces/IInput";
import type { IDataConsumer } from "../../Measurements/Interfaces/IDataConsumer";
import type { IActionT } from "../../Interfaces/IActionT";
import type { IAction } from "../../Interfaces/IAction";
import type { IScadaInterface } from "../../Scada/Interfaces/IScadaInterface";
import { EngineGame } from "../../Game/Abstract/EngineGame";
import { ScadaScene } from "../../Game/Scenes/ScadaScene";
import { PerformerMeasuremets } from "../../Measurements/PerformerMeasuremets";
import { ActionArray } from "../../Utilities/Generic/ActionArray";
import { ExternalWatch } from "../../Utilities/Watch/ExternalWatch";

export abstract class PerformerRealtime extends PerformerMeasuremets implements IActionT<number>, IAction {
    constructor(factory: IFactory, desktop: IDesktop, interval: number, chart: string) {
        super(factory)
        this.types.push("PerformerRealtime")
        this.typeName = "PerformerRealtime"
        this.engine = new ExternalWatch(interval, new ActionArray)
        let ic = desktop as unknown as IComponentCollection
       // this.setTimeProviderCollection(ic, this.engine)
        this.game = new EngineGame("", this.factory, this.engine, false);
        this.scene = new ScadaScene(this.game, ic, chart, this.engine)
        let sc = this.scene.getConsumerScada()
        this.scada = sc
        let ii = sc.getScadaInputs()
        for (var i of ii) this.inputs.push(i)
        this.dataConsumer = this.scada.getScadaObject<IDataConsumer>(chart, "IDataConsumer")[0]
        this.setTimeProviderCollection(ic, this.engine)

    }

    actionT(t: number): void {
        this.engine.actionT(t);
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


    protected abstract prepare() : void

    public loadGame(): void {
        this.game.loadItself(true);
        this.game.startItself(true);
    }

    protected game!: EngineGame

    protected dataConsumer !: IDataConsumer


    protected inputs: IInput[] = []

    protected scada !: IScadaInterface

    protected scene !: ScadaScene


    protected engine !: ExternalWatch// ActionWatch = new ActionWatch(500, new ActionArray)


}