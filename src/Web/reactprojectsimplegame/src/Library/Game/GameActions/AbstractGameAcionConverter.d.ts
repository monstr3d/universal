import type { IAction } from "../../Interfaces/IAction";
import { AbstractGameObject } from "../Abstract/AbstractGameObject";
import type { IGameActionConverter } from "../Interfaces/IGameActionConverter";
export declare abstract class AbstractGameAcionConverter extends AbstractGameObject implements IGameActionConverter {
    abstract functT(s: IAction): IAction | undefined;
    constructor();
}
//# sourceMappingURL=AbstractGameAcionConverter.d.ts.map