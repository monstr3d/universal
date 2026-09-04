import type { IComponentCollection } from "./IComponentCollection";

export interface IComponentCollectionHolder {
    getComponentCollection(): IComponentCollection
    setComponentCollection(collection: IComponentCollection) : void

}