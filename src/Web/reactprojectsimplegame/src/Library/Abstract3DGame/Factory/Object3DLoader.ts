import type { IObject } from "../../Interfaces/IObject";
import { Basic3DShape } from "../../Motion6D/Objects/Shapes/Basic3DShape";
import { Performer } from "../../Performer";
import { Scene3DMesh } from "../SceneObjects/Scene3DMesh";
import { BasicGameLoader } from "./BasicGameLoader";

export class Object3DLoader extends BasicGameLoader {
    performer : Performer = new Performer()

    loadObject(parent: IObject, child: IObject): void {
        super.loadObject(parent, child)
        var b3s = this.performer.convertObject<Basic3DShape, IObject>(child, "Basic3DShape")
        if (b3s.length > 0) {
            new Scene3DMesh(this.scene, b3s[0])
        }
    }
}