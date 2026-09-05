import type { IMeshHolder } from "../../Abstract3DConverters/Interfaces/IMeshHolder";
import { AbstractGameAcionConverter } from "../../Game/GameActions/AbstractGameAcionConverter";
import type { ISceneObjectAction } from "../../Game/Interfaces/ISceneObjectAction";
import type { IAction } from "../../Interfaces/IAction";
import { ReferenceFrame } from "../../Motion6D/ReferenceFrame";
import { BasicCamera } from "../../Motion6D/Visible/BasicCamera";
import { ActionArray } from "../../Utilities/Generic/ActionArray";
import { DrawMesh } from "../Factory/DrawMesh";

export class DrawMeshGameCameraAcionConverter extends AbstractGameAcionConverter {
    constructor(camera: BasicCamera) {
        super()
        this.typeName = "DrawMeshGameCameraAcionConverter"
        this.types.push("DrawMeshGameCameraAcionConverter")
        this.camera = camera
    }

    protected createDraw(camera: BasicCamera): DrawMesh {
        return new DrawMesh(camera)
    } 

    functT(s: IAction): IAction | undefined {
        var sc = s as unknown as ISceneObjectAction
        if (sc == undefined) return undefined
        var ob = sc.getActionSceneObject();
        var mh = ob as unknown as IMeshHolder
        if (mh === undefined) return undefined
        var meshes = mh.getHolderMeshes()
        var fr = sc.getActionSceneAdditionalObject()
        var frame = fr as unknown as ReferenceFrame
        var dm = this.createDraw(this.camera)
        let action = new ActionArray();
        action.addAction(s)
        for (let mesh of meshes) {
            let a = dm.drawMeshRecursively(mesh, frame)
            action.addAction(a)
        }
        return action
    }

    camera !: BasicCamera
}
