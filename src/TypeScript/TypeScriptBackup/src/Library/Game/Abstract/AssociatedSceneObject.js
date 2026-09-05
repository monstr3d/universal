"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AssociatedSceneObject = void 0;
const AbstractSceneObject_1 = require("./AbstractSceneObject");
const TextReaderFromResource_1 = require("../../Resources/TextReaderFromResource");
class AssociatedSceneObject extends AbstractSceneObject_1.AbstractSceneObject {
    constructor(scene, object) {
        super(scene, object.getName());
        this.show = undefined;
        this.resourceFactory = undefined;
        this.types.push("IAssociatedObject");
        this.types.push("AbstractSceneObject");
        this.typeName = "AbstractSceneObject";
        this.object = object;
        this.factory = scene.getConsumerFactory();
        this.show = this.factory.getFactory("IShowObject");
        this.resourceFactory = this.factory.getFactory("IResourceFuncFactory");
    }
    getTextFactory(f, items) {
        if (f != undefined)
            return f;
        const ff = this.factory.getFactory("ITextReaderFactory");
        if (ff != undefined)
            return ff;
        if (this.resourceFactory != undefined) {
            const tt = new TextReaderFromResource_1.TextReaderFromResource(items, this.resourceFactory);
            return tt;
        }
    }
    showObject(object, str) {
        if (this.show != undefined)
            this.show.show(object, str);
    }
    getAssociatedObject() {
        return this.object;
    }
    setAssociatedObject(obj) {
        this.object = obj;
    }
}
exports.AssociatedSceneObject = AssociatedSceneObject;
//# sourceMappingURL=AssociatedSceneObject.js.map