import type { IComponentCollection } from "./IComponentCollection";
import type { IRealtimeCollection } from "./IRealtimeCollection";
import type { IDataConsumer } from "../Measurements/Interfaces/IDataConsumer";
import type { IFactory } from "./IFactory";

export interface IRealtimeCollectionFactory {

    createRealtimeFromCollection(collection: IComponentCollection, factory: IFactory): IRealtimeCollection
    createRealtimeFromDataConsumer(consumer: IDataConsumer, factory: IFactory): IRealtimeCollection
}