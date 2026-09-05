"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractScene = void 0;
const ActionArray_1 = require("../../Utilities/Generic/ActionArray");
const ScenePerformer_1 = require("../ScenePerformer");
class AbstractScene {
    constructor(game, name) {
        this.externalAction = new ActionArray_1.ActionArray();
        this.internalAction = new ActionArray_1.ActionArray();
        this.objects = [];
        this.children = [];
        this.objectMap = new Map();
        this.isStarted = false;
        this.isLoaded = false;
        this.currentTime = Number.MAX_VALUE;
        this.typeName = "AbstractScene";
        this.types = ["IObject", "IChildrenT<ISceneObject>", "ISelfLoad",
            "IAddAction", "ISelfStart", "IObjectCollection", "IExternalAction",
            "IFactoryConsumer", "IScene", "AbstractScene"];
        this.name = "";
        this.game = game;
        this.factory = game.getConsumerFactory();
        this.name = name;
        this.performer = new ScenePerformer_1.ScenePerformer(this);
        game.addChildT(this);
    }
    actionT(t) {
        if (this.stepAction === undefined)
            return;
        if (this.currentTime > t) {
            this.currentTime = t;
            return;
        }
        this.stepAction.actionT2(this.currentTime, t);
        this.currentTime = t;
    }
    isEmptyActionT() {
        return false;
    }
    isRunning() {
        return this.isStarted;
    }
    getSceneObject(name) {
        if (this.objectMap.has(name))
            return this.objectMap.get(name);
        return undefined;
    }
    getGame() {
        return this.game;
    }
    getObjectCollection() {
        return this.objects;
    }
    getInternalAction() {
        return this.internalAction;
    }
    getExternalAction() {
        return this.externalAction;
    }
    setConsumerFactory(factory) {
        this.factory = factory;
        this.performer.setFactoryToObjectCollection(this, factory);
    }
    getConsumerFactory() {
        return this.factory;
    }
    startItself(start) {
        if (this.isStarted == start)
            return false;
        this.isStarted = start;
        this.performer.startCollecion(start, this);
        return true;
    }
    addAction(action, add) {
        if (add)
            this.externalAction.addAction(action);
        else
            this.externalAction.removeAction(action);
    }
    loadItself(load) {
        if (this.isLoaded == load)
            return false;
        this.isLoaded = load;
        this.performer.loadCollecion(load, this);
        return true;
    }
    getChildernT() {
        return this.children;
    }
    addChildT(child) {
        var b = this.performer.addUnique(this.children, child);
        if (b) {
            this.objects.push(child);
            var name = child.getName();
            if (!this.objectMap.has(name)) {
                this.objectMap.set(name, child);
            }
        }
    }
    removeChildT(child) {
        var b = this.performer.remove(this.children, child);
        if (b) {
            this.performer.remove(this.objects, child);
            var name = child.getName();
            if (this.objectMap.has(name))
                this.objectMap.delete(name);
        }
    }
    setFactoryToChildren() {
        this.performer.setFactoryToObjectCollection(this, this.getConsumerFactory());
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
exports.AbstractScene = AbstractScene;
//# sourceMappingURL=AbstractScene.js.map