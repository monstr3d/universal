"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Object3DLoader = void 0;
const Performer_1 = require("../../Performer");
const Scene3DMesh_1 = require("../SceneObjects/Scene3DMesh");
const BasicGameLoader_1 = require("./BasicGameLoader");
class Object3DLoader extends BasicGameLoader_1.BasicGameLoader {
    constructor() {
        super(...arguments);
        this.performer = new Performer_1.Performer();
    }
    loadObject(parent, child) {
        super.loadObject(parent, child);
        var b3s = this.performer.convertObject(child, "Basic3DShape");
        if (b3s.length > 0) {
            new Scene3DMesh_1.Scene3DMesh(this.scene, b3s[0]);
        }
    }
}
exports.Object3DLoader = Object3DLoader;
//# sourceMappingURL=Object3DLoader.js.map