import type { IActionAddRemoveT } from "../../Interfaces/IActionAddRemoveT";
import type { IActionT } from "../../Interfaces/IActionT";
import type { IFactory } from "../../Interfaces/IFactory";
import type { IPlayEngine } from "../../Interfaces/IPlayEngine";
import { AbstractGame } from "./AbstractGame";
export declare class EngineGame extends AbstractGame implements IPlayEngine, IActionT<number> {
    constructor(name: string, factory: IFactory, engine: IPlayEngine, useLoader: boolean);
    cycle(time: number): void;
    actionT(t: number): void;
    isEmptyActionT(): boolean;
    protected engineIsRunning: boolean;
    getGameEngine(): IPlayEngine;
    startItself(start: boolean): boolean;
    run(): void;
    isEngineEnabled(): boolean;
    setEngineEnabled(enabled: boolean): boolean;
    getEngineAction(): IActionAddRemoveT<number>;
    engineAction: IActionAddRemoveT<number>;
    engine: IPlayEngine;
}
//# sourceMappingURL=EngineGame.d.ts.map