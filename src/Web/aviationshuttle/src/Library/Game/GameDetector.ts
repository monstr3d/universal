
import { FactoryObject } from "../FactoryObject";
import type { IFactory } from "../Interfaces/IFactory";
import type { IGame } from "./Interfaces/IGame";
import type{ IGameDetector } from "./Interfaces/IGameDetector";

export class GameDetector extends FactoryObject implements IGameDetector {
    detectGame(): IGame {
        return this.game
    }

    constructor(game: IGame, factory: IFactory | undefined) {
        super("", factory)
        this.types.push("IGameDetector")
        this.types.push("GameDetector")
        this.typeName = "GameDetector"
        this.game = game
    }

    game !: IGame
}