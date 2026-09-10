import { FactoryObject } from "../FactorytObject";
import type { IFactory } from "../Interfaces/IFactory";
import type { IGame } from "./Interfaces/IGame";
import type { IGameDetector } from "./Interfaces/IGameDetector";
export declare class GameDetector extends FactoryObject implements IGameDetector {
    detectGame(): IGame;
    constructor(game: IGame, factory: IFactory | undefined);
    game: IGame;
}
//# sourceMappingURL=GameDetector.d.ts.map