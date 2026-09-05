"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DrawMeshGameCameraAcionConverter = void 0;
const AbstractGameAcionConverter_1 = require("../../Game/GameActions/AbstractGameAcionConverter");
const ActionArray_1 = require("../../Utilities/Generic/ActionArray");
const DrawMesh_1 = require("../Factory/DrawMesh");
class DrawMeshGameCameraAcionConverter extends AbstractGameAcionConverter_1.AbstractGameAcionConverter {
    constructor(camera) {
        super();
        this.typeName = "DrawMeshGameCameraAcionConverter";
        this.types.push("DrawMeshGameCameraAcionConverter");
        this.camera = camera;
    }
    createDraw(camera) {
        return new DrawMesh_1.DrawMesh(camera);
    }
    functT(s) {
        var sc = s;
        if (sc == undefined)
            return undefined;
        var ob = sc.getActionSceneObject();
        var mh = ob;
        if (mh === undefined)
            return undefined;
        var meshes = mh.getHolderMeshes();
        var fr = sc.getActionSceneAdditionalObject();
        var frame = fr;
        var dm = this.createDraw(this.camera);
        let action = new ActionArray_1.ActionArray();
        action.addAction(s);
        for (let mesh of meshes) {
            let a = dm.drawMeshRecursively(mesh, frame);
            action.addAction(a);
        }
        return action;
    }
}
exports.DrawMeshGameCameraAcionConverter = DrawMeshGameCameraAcionConverter;
//# sourceMappingURL=DrawMeshGameCameraAcionConverter.js.map