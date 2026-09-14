import { EmptyObject } from "../EmptyObject"
import { PerformerRealtime } from "../Event/Wrappers/PerformerRealtime"
import { IGameAction } from "../Game/Interfaces/IGameAction"
import { IGameActionFactory } from "../Game/Interfaces/IGameActionFactory"
import { IGameLoaderFactory } from "../Game/Interfaces/IGameLoaderFactory"
import { ISceneObject } from "../Game/Interfaces/ISceneObject"
import { IAction } from "../Interfaces/IAction"
import { IDesktop } from "../Interfaces/IDesktop"
import { IFactory } from "../Interfaces/IFactory"
import { IRealtimeCollectionFactory } from "../Interfaces/IRealtimeCollectionFactory"
import { IDifferentialEquationProcessor } from "../Measurements/DifferentialEquations/Interfaces/IDifferentialEquationProcessor "
import { RungeProcessor } from "../Measurements/DifferentialEquations/Processors/RungeProcessor"
import { Motion6DFactory } from "../Motion6D/Motion6DFactory"
import { Motion6DRealtimeFactory } from "../Motion6D/Runtime/Event/Motion6DRealtimeFactory"
import { ResourceFuncFactory } from "../Resources/ResourceFuncFactory"
import { UniversalFactory } from "../UniversalFactory"
import { IStringSplitter } from "../Utilities/String/Interfaces/IStringSplitter"
import { LineEndSplitter } from "../Utilities/String/LineEndSplitter"
import { BasicGameLoaderFactory } from "./Factory/BacicGameLoaderFactory"


export class Game3DRealtime extends PerformerRealtime {

    constructor(factory: IFactory, desktop: IDesktop, interval: number, chart: string) {
        super(factory, desktop, interval, chart)
    }

    protected prepare(): void {
    }

}


export const getFactory = (): IFactory => {
    let f = new UniversalFactory()
    f.addFactory<IGameActionFactory>(new GA, "IGameActionFactory")
    f.addFactory<IGameLoaderFactory>(new BasicGameLoaderFactory(), "IGameLoaderFactory")
    f.addFactory<IStringSplitter>(new LineEndSplitter(), "IStringSplitter")
    let rf = new ResourceFuncFactory("", undefined);
    let processor = new RungeProcessor();
    f.addFactory<IDifferentialEquationProcessor>(processor, "IDifferentialEquationProcessor")
    let fm = new Motion6DRealtimeFactory(new Motion6DFactory)
    f.addFactory<IRealtimeCollectionFactory>(fm, "IRealtimeCollectionFactory")

    f.addFactory<ResourceFuncFactory>(rf, "IResourceFuncFactory")

    return f
}

class GA extends EmptyObject implements IGameActionFactory, IGameAction, IAction {
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
        return this
    }
    getGameAction(object: any): IGameAction | undefined {
        return this
    }
}

