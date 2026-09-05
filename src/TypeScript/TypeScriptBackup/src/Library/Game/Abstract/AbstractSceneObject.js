"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractSceneObject = void 0;
class AbstractSceneObject {
    constructor(scene, name) {
        this.typeName = "AbstractSceneObject";
        this.types = ["IObject", "ISceneObject", "IFactoryConsumer", "AbstractSceneObject"];
        this.name = "";
        this.scene = scene;
        scene.addChildT(this);
        this.name = name;
    }
    setConsumerFactory(factory) {
        this.factory = factory;
    }
    getConsumerFactory() {
        return this.factory;
    }
    getScene() {
        return this.scene;
    }
    getName() {
        return this.name;
    }
    getClassName() {
        return this.typeName;
    }
    imlplementsType(type) {
        var b = this.types.includes(type);
        return b;
    }
}
exports.AbstractSceneObject = AbstractSceneObject;
//# sourceMappingURL=AbstractSceneObject.js.map