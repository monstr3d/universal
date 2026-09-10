import type { IGame } from "../../Game/Interfaces/IGame"
import type { IGameLoaderFactory } from "../../Game/Interfaces/IGameLoaderFactory"
import type { IComponentCollection } from "../../Interfaces/IComponentCollection"
import type { IObject } from "../../Interfaces/IObject"
import type { IPlayEngine } from "../../Interfaces/IPlayEngine"
import type { IStepActionHolder } from "../../Measurements/Interfaces/IStepActionHolder"
import type { IStepAction } from "../../Measurements/Interfaces/IStepAction"
import type { IScadaConsumer } from "../../Scada/Interfaces/IScadaConsumer"
import type { IScadaInterface } from "../../Scada/Interfaces/IScadaInterface"
import { ScadaDesktop } from "../../Scada/ScadaDesktop"
import { ScadaDesktopEngine } from "../../Scada/ScadaDesktopEngine"
import { AbstractScene } from "../../Game/Abstract/AbstractScene"

export class ScadaScene extends AbstractScene implements IScadaConsumer
{
    constructor(game: IGame, collection: IComponentCollection, chart: string) {
        super(game, chart)
        this.types.push("IScadaConsumer")
        this.collection = collection
        var engine = this.performer.convertObject<IPlayEngine, IObject>(game, "IPlayEngine")
        if (engine.length > 0) this.scada = new ScadaDesktopEngine(collection, engine[0],
            this.factory, this.name)
        else this.scada = new ScadaDesktop(collection)
        
        var lc = this.factory.getFactory<IGameLoaderFactory>("IGameLoaderFactory")
        var loader = lc?.getLoader(this)
        if (loader != undefined) {
            this.performer.loadChildren(this, this.scada, loader, true)
        }
        this.setFactoryToChildren()
        let sa = this.getStepAction()
        if (sa != undefined) {
            this.stepAction = sa
        }
    }

    protected collection !: IComponentCollection
    protected scada !: IScadaInterface

    getStepAction(): IStepAction | undefined {
        let sh = this.scada as unknown as IStepActionHolder
        if (sh === undefined) return undefined
        return sh.getStepAction()
    }


    getConsumerScada(): IScadaInterface {
        return this.scada;
    }

    setConsumerScada(scada: IScadaInterface): boolean {
        this.scada = scada
        return false
    }

    loadItself(load: boolean): boolean {
        if (!super.loadItself(load)) return false
        if (load) this.performer.createSceneAction()
        else this.internalAction.clearActions()
        return true;
        
    }
    startItself(start: boolean): boolean {
        if (this.isStarted == start) return false
        this.isStarted = start
        this.scada.setScadaEnabled(start)
        this.performer.startCollecion(start, this);
        this.currentTime = Number.MAX_VALUE
        return true;
    }


}
