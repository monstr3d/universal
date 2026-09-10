import { AbstractGameAction } from "../../Game/Abstract/AbstractGameAction";
import type { ISceneObject } from "../../Game/Interfaces/ISceneObject";
import type { IAction } from "../../Interfaces/IAction";
import type { IFactory } from "../../Interfaces/IFactory";
export declare class EmptyGameAction extends AbstractGameAction implements IAction {
    constructor(name: string, factory: IFactory | undefined);
    action(): void;
    isEmptyAction(): boolean;
    functT(s: ISceneObject): IAction | undefined;
    protected s: ISceneObject;
}
//# sourceMappingURL=EmptyGameAction.d.ts.map