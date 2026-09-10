import { AbstractGameObject } from "../../Game/Abstract/AbstractGameObject";
import { BasicCamera } from "../../Motion6D/Visible/BasicCamera";
import type { IFindCamera } from "../Interfaces/IFindCamera";
import type { IScene } from "../../Game/Interfaces/IScene";
export declare class ScadaFindCamera extends AbstractGameObject implements IFindCamera {
    functT(s: IScene): BasicCamera | undefined;
    constructor(name: string);
}
//# sourceMappingURL=ScadaFindCamera.d.ts.map