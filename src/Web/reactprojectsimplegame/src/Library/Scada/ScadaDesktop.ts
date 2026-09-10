import type { IComponentCollection } from "../Interfaces/IComponentCollection";
import type { IComponentCollectionHolder } from "../Interfaces/IComponentCollectionHolder";
import type { IObject } from "../Interfaces/IObject";
import type { IObjectCollection } from "../Interfaces/IObjectCollection";
import type { IRealtimeCollection } from "../Interfaces/IRealtimeCollection";
import type { IStepAction } from "../Measurements/Interfaces/IStepAction";
import type { IStepActionHolder } from "../Measurements/Interfaces/IStepActionHolder";
import { ScadaInterface } from "./ScadaInterface";

export  class ScadaDesktop extends ScadaInterface implements IComponentCollectionHolder {

    constructor(componentCollection: IComponentCollection) {
        super()
        this.types.push("ScadaDesktop")
        this.types.push("IComponentCollectionHolder")
        this.typeName = "ScadaDesktop"
        this.componentCollection = componentCollection;
        let oc = componentCollection as IObjectCollection
        this.performer.getInputsFromCollection(oc, this.inputs)
    }

    getComponentCollection(): IComponentCollection {
        return this.componentCollection
    }
    setComponentCollection(collection: IComponentCollection): void {
        this.componentCollection = collection
    }
    
    getObjectCollection(): IObject[] {
        return this.componentCollection.getObjectCollection()
    }
    getScadaObject<T>(name: string, type: string): T[] {

        return this.performer.getCollectionObject<T>(this.componentCollection, name, type)
    }

    protected componentCollection !: IComponentCollection;

    protected runtime !: IRealtimeCollection;


    setScadaEnabled(enabled: boolean): void {
        super.setScadaEnabled(enabled)
        this.runtime.setComponentCollectionRunning(enabled);
    }

    isScadaEnabled(): boolean {
        return this.runtime.isComponentCollectionRunning();
    }

    public createRuntime(): void {

    }

    getStepAction(): IStepAction | undefined {
        let l = this.performer.convertObject<IStepActionHolder, IRealtimeCollection>(this.runtime, "IStepActionHolder")
        return l.length == 0 ? undefined : l[0].getStepAction()
    }

}