import { AbstractAction } from "./src/Library/Event/Objects/AbstractAction";
import { IGame } from "./src/Library/Game/Interfaces/IGame";
import { IFactory } from "./src/Library/Interfaces/IFactory";
export declare class Actor {
    factory: IFactory;
    game: IGame;
    url: string;
    p(): Promise<void>;
    constructor();
    loadGame(): void;
    dir: string;
    actPI(): void;
    actAirplane(): void;
}
export declare class A extends AbstractAction {
    s: string;
    i: number;
    constructor(s: string);
    action(): void;
}
//# sourceMappingURL=Actor.d.ts.map