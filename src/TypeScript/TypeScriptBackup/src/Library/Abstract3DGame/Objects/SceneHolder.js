"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SceneHolder = void 0;
const Performer_1 = require("../../Performer");
class SceneHolder {
    constructor(scene) {
        this.performer = new Performer_1.Performer();
        this.typeName = "SceneHolder";
        this.types = ["IObject", "SceneHolder"];
        this.name = "";
        this.performer = new Performer_1.Performer();
        this.scene = this.performer.convertObject(scene, "IScene")[0];
    }
    getName() {
        return this.name;
    }
    getClassName() {
        return this.typeName;
    }
    imlplementsType(type) {
        return this.types.includes(type);
    }
}
exports.SceneHolder = SceneHolder;
//# sourceMappingURL=SceneHolder.js.map