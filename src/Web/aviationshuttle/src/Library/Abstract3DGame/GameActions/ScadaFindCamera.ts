import { AbstractGameObject } from "../../Game/Abstract/AbstractGameObject";
import { BasicCamera } from "../../Motion6D/Visible/BasicCamera";
import type { IFindCamera } from "../Interfaces/IFindCamera";
import type { IScene } from "../../Game/Interfaces/IScene";


export class ScadaFindCamera extends AbstractGameObject implements IFindCamera {
    functT(s: IScene): BasicCamera | undefined {
        var sc = this.performer.sceneToScada(s);
        if (sc === undefined) return undefined;
        var ob = sc.getScadaObject<BasicCamera>(this.name, "BasicCamera");
        if (ob.length > 0) return ob[0];
        return undefined;
    }
    constructor(name: string) {
        super(name, undefined);
        this.types.push("IFindCamera");
        this.types.push("ScadaFindCamera");
        this.typeName = "ScadaFindCamera";
    }

}
