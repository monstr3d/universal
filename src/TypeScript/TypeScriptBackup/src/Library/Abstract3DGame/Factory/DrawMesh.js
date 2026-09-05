"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DrawMesh = void 0;
const EmptyObject_1 = require("../../EmptyObject");
const DrawMeshAction_1 = require("./DrawMeshAction");
class DrawMesh extends EmptyObject_1.EmptyObject {
    constructor(camera) {
        super("");
        this.typeName = "AbstractDrawMesh";
        this.types.push("IDrawMesh");
        this.types.push("AbstractDrawMesh");
        this.camera = camera;
    }
    createAction(camera, mesh, frame) {
        return new DrawMeshAction_1.DrawMeshAction(camera, mesh, frame);
    }
    drawMeshRecursively(mesh, frame) {
        var int = new InternlalAction(this, frame);
        return this.performer.getActionFromNode(mesh, int);
    }
    drawMesh(mesh, frame) {
        return this.createAction(this.camera, mesh, frame);
    }
}
exports.DrawMesh = DrawMesh;
class InternlalAction {
    constructor(abs, frame) {
        this.abs = abs;
        this.frame = frame;
    }
    functT(s) {
        return this.abs.drawMesh(s, this.frame);
    }
}
//# sourceMappingURL=DrawMesh.js.map