"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Scene3DMesh = void 0;
const Obj3DCreator_1 = require("../../Abstract3DConverters/MeshCreators/Obj3DCreator");
const AssociatedSceneObject_1 = require("../../Game/Abstract/AssociatedSceneObject");
class Scene3DMesh extends AssociatedSceneObject_1.AssociatedSceneObject {
    constructor(scene, object) {
        super(scene, object);
        this.meshes = [];
        this.isLoaded = false;
        this.types.push("IMeshHolder");
        this.types.push("ISelfLoad");
        this.types.push("Scene3DMesh");
        this.types.push("IResourceCollection");
        this.typeName = "Scene3DMesh";
        this.shape = object;
    }
    createTextReaderFactory() {
        this.textReader = this.getTextFactory(this.textReader, this.getResources());
    }
    setScene(scene) {
        this.scene = scene;
    }
    getResources() {
        return this.shape.getResources();
    }
    loadItself(load) {
        if (load == this.isLoaded)
            return false;
        this.isLoaded = load;
        this.createTextReaderFactory();
        this.loadMesh(load);
        return true;
    }
    getHolderMeshes() {
        return this.meshes;
    }
    loadMesh(load) {
        if (!load)
            return;
        var res = this.shape.getResources();
        for (var r of res) {
            if (r.ext == ".obj") {
                var creator = new Obj3DCreator_1.Obj3DCreator(r.url, r.name, "", this.scene, this.factory, this.textReader);
                this.meshes = creator.getMeshCreatorMeshes();
                break;
            }
        }
    }
}
exports.Scene3DMesh = Scene3DMesh;
//# sourceMappingURL=Scene3DMesh.js.map