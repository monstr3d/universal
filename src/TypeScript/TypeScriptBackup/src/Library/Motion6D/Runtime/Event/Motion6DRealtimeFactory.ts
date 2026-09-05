import type { IRealtimeCollectionFactory } from "../../../Interfaces/IRealtimeCollectionFactory";
import type { IComponentCollection } from "../../../Interfaces/IComponentCollection";
import type { IRealtimeCollection } from "../../../Interfaces/IRealtimeCollection";
import type { IDataConsumer } from "../../../Measurements/Interfaces/IDataConsumer";
import { DataRuntimeConsumerMotion6DEvent } from "./DataRuntimeConsumerMotion6DEvent";
import { Motion6DFactory } from "../../Motion6DFactory";
import { EmptyRealtimeCollection } from "../../../Runtime/EmptyRealtimeCollection";
import { FactoryObject } from "../../../FactoryObject";

export class Motion6DRealtimeFactory extends FactoryObject implements IRealtimeCollectionFactory {
    constructor(mF: Motion6DFactory) {
        super("", mF)
        this.mF = mF;
        this.types.push("IRealtimeCollectionFactory")
        this.types.push("Motion6DRealtimeFactory")
        this.typeName = "Motion6DRealtimeFactory"
    }

    createRealtimeFromCollection(collection: IComponentCollection): IRealtimeCollection {
        this.collection = collection
        return new EmptyRealtimeCollection()
    }

    collection!: IComponentCollection

    mF !: Motion6DFactory 

    createRealtimeFromDataConsumer(consumer: IDataConsumer): IRealtimeCollection {
        return new DataRuntimeConsumerMotion6DEvent(consumer, this.mF)
    }


}