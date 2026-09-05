import type { IScene } from "../../Game/Interfaces/IScene";
import type { IPosition } from "../../Motion6D/Interfaces/IPosition";
import type { IReferenceFrame } from "../../Motion6D/Interfaces/IReferenceFrame";
import { AbstractFindFrame } from "./AbstractFindFrame";

export class ScadaFind3dFrame extends AbstractFindFrame {
    constructor(name: string) {
        super(name)
        this.types.push("ScadaFindFrame")
        this.typeName = "ScadaFindFrame"
    }
  
    functT(s: IScene): IReferenceFrame | undefined {
        var sc = this.performer.sceneToScada(s);
        if (sc === undefined) return undefined
        var ob = sc.getScadaObject<IPosition>(this.name, "IPosition")
        if (ob.length > 0) {
            var p = ob[0]
            var rf = this.performer.convertObject<IReferenceFrame, IPosition>(p, "IReferenceFrame")
            if (rf.length > 0) return rf[0]
            return p.getParentFrame()
        }
        return undefined
    }

}