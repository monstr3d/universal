import type { IFactory } from "../Interfaces/IFactory";
import type { IPlayEngine } from "../Interfaces/IPlayEngine";
import type { GameOptions } from "./interfaces/IGameOptions";
import type { IGameActionConverter } from "../Game/Interfaces/IGameActionConverter";
import { EngineGameCameraAction } from "../Abstract3DGame/Games/EngineGameCameraAction";
import { BasicCamera } from "../Motion6D/Visible/BasicCamera";
export declare class GLGame extends EngineGameCameraAction {
    constructor(name: string, factory: IFactory, engine: IPlayEngine, useLoader: boolean, canvas: HTMLCanvasElement, options: GameOptions);
    cycle(time: number): void;
    protected getGameActionConverterCamera(camera: BasicCamera): IGameActionConverter;
    canvas: HTMLCanvasElement;
    gl: WebGL2RenderingContext;
    nextSceneReady: boolean;
    lastTick: number;
    options: GameOptions;
}
//# sourceMappingURL=GLGame.d.ts.map