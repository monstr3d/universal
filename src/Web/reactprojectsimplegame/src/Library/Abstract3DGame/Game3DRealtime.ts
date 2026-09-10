import type { IDesktop } from "../Interfaces/IDesktop";
import type { IFactory } from "../Interfaces/IFactory";
import type { IRealtimeCollectionFactory } from "../Interfaces/IRealtimeCollectionFactory";
import type { IDifferentialEquationProcessor } from "../Measurements/DifferentialEquations/Interfaces/IDifferentialEquationProcessor ";
import type { IMtlDetector } from "../Abstract3DConverters/Interfaces/IMtlDetector";
import type { IGameAction } from "../Game/Interfaces/IGameAction";
import type { IGameActionFactory } from "../Game/Interfaces/IGameActionFactory";
import type { IGameLoaderFactory } from "../Game/Interfaces/IGameLoaderFactory";
import type { ISceneObject } from "../Game/Interfaces/ISceneObject";
import type { IAction } from "../Interfaces/IAction";
import type { IStringSplitter } from "../Utilities/String/Interfaces/IStringSplitter";
import { RungeProcessor } from "../Measurements/DifferentialEquations/Processors/RungeProcessor";
import { Motion6DRealtimeFactory } from "../Motion6D/Runtime/Event/Motion6DRealtimeFactory";
import { PerformerRealtime } from "../Event/Wrappers/PerformerRealtime";
import { Motion6DFactory } from "../Motion6D/Motion6DFactory";
import { ResourceFuncFactory } from "../Resources/ResourceFuncFactory";
import { UniversalFactory } from "../UniversalFactory";
import { LineEndSplitter } from "../Utilities/String/LineEndSplitter";
import { BasicGameLoaderFactory } from "./Factory/BacicGameLoaderFactory";
import { EmptyObject } from "../EmptyObject";


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

