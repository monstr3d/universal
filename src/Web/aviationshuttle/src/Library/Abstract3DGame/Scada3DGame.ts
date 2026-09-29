import type { IComponentCollection } from "../Interfaces/IComponentCollection";
import type { IFactory } from "../Interfaces/IFactory";
import type { IPlayEngine } from "../Interfaces/IPlayEngine";
import type { IRealtimeCollectionFactory } from "../Interfaces/IRealtimeCollectionFactory";
import { Motion6DFactory } from "../Motion6D/Motion6DFactory";
import { Motion6DRealtimeFactory } from "../Motion6D/Runtime/Event/Motion6DRealtimeFactory";
import { AbstractScadaGame } from "../Game/Abstract/AbstractScadaGame";

export class Scada3DGame extends AbstractScadaGame 
{
    constructor(name: string, factory: IFactory | undefined, collection : IComponentCollection, chart: string, interval : number,
        engine?: IPlayEngine | undefined)
        {
            super(name, factory, collection, chart, interval)
        }

    protected post(factory: IFactory | undefined, collection: IComponentCollection): void {
        super.post(factory, collection)
           if (factory === undefined) return
        let f = factory
  let fm = new Motion6DRealtimeFactory(new Motion6DFactory)
    f.addFactory<IRealtimeCollectionFactory>(fm, "IRealtimeCollectionFactory")

  }

}