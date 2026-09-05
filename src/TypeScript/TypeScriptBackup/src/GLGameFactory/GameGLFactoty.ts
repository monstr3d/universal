import { IMtlDetector } from "../Library/Abstract3DConverters/Interfaces/IMtlDetector";
import { BasicGameLoaderFactory } from "../Library/Abstract3DGame/Factory/BacicGameLoaderFactory";
import { IGameActionFactory } from "../Library/Game/Interfaces/IGameActionFactory";
import { IGameLoaderFactory } from "../Library/Game/Interfaces/IGameLoaderFactory";
import { Motion6DFactory } from "../Library/Motion6D/Motion6DFactory";
import { IStringSplitter } from "../Library/Utilities/String/Interfaces/IStringSplitter";
import { LineEndSplitter } from "../Library/Utilities/String/LineEndSplitter";

export class GameGLFactory extends Motion6DFactory {
    constructor(gameActionFactory: IGameActionFactory) {
        super()
        this.addFactory<IGameLoaderFactory>(new BasicGameLoaderFactory(), "IGameLoaderFactory")
        //this.addFactory<IMtlDetector>(mtl, "IMtlDetector")
        this.addFactory<IStringSplitter>(new LineEndSplitter(), "IStringSplitter")
        this.addFactory<IGameActionFactory>(gameActionFactory, "IGameActionFactory")
  }
}