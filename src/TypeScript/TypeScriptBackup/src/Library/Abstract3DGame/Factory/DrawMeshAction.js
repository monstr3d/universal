"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DrawMeshAction = void 0;
const EmptyGame3DObject_1 = require("../EmptyGame3DObject");
class DrawMeshAction extends EmptyGame3DObject_1.EmptyGame3DObject {
    constructor(camera, mesh, frame) {
        super("");
        this.vertices = [];
        this.normals = [];
        this.textutes = [];
        this.near = 0;
        this.far = 0;
        this.field = 0;
        this.types.push("IAction");
        this.types.push("DrawMeshAction");
        this.camera = camera;
        this.mesh = mesh;
        this.frame = frame;
        this.near = camera.getNearDistance();
        this.far = camera.getFarDistance();
        this.field = camera.getFieldOfView();
        this.performer.createMirrorArray2(this.vertices, mesh.getVertices(), 0);
        this.performer.createMirrorArray2(this.textutes, mesh.getTextures(), 0);
        this.performer.createMirrorArray2(this.normals, mesh.getNormals(), 0);
    }
    action() {
        let v = this.mesh.getVertices();
        this.performer.setInvertedCoorfinates2(this.vertices, v, this.frame);
    }
    isEmptyAction() {
        return false;
    }
}
exports.DrawMeshAction = DrawMeshAction;
//# sourceMappingURL=DrawMeshAction.js.map