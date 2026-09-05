"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractGame = void 0;
const ActionArray_1 = require("../../Utilities/Generic/ActionArray");
const GameDetector_1 = require("../GameDetector");
const GamePerformer_1 = require("../GamePerformer");
const AbstractGameObject_1 = require("./AbstractGameObject");
const Loader_1 = __importDefault(require("../../RemoteResuorces/Loader"));
const ActionArrayT_1 = require("../../Utilities/Generic/ActionArrayT");
class AbstractGame extends AbstractGameObject_1.AbstractGameObject {
    constructor(name, factory, useLoader) {
        super(name, factory);
        this.performer = new GamePerformer_1.GamePerformer();
        this.typeName = "AbstractGame";
        this.types = ["IObject", "IGame", "IChildrenT<IScene>", "ISelfLoad",
            "IAddAction", "SelfStart", "IObjectCollection", "IExternalAction",
            "IFactoryConsumer", "AbstractGame"];
        this.name = "";
        this.scenes = new Map();
        this.children = [];
        this.objects = [];
        this.internalAction = new ActionArray_1.ActionArray();
        this.isStarted = false;
        this.isLoaded = false;
        this.intAct = new ActionArray_1.ActionArray;
        this.areResourcesLoaded = false;
        this.resources = [];
        this.useLoader = false;
        this.resourcesI = new Map();
        this.onLoad = new ActionArray_1.ActionArray();
        this.timeAction = new ActionArrayT_1.ActionArrayT();
        this.internaTimeAction = new ActionArrayT_1.ActionArrayT();
        this.externalAction = new ActionArray_1.ActionArray();
        this.types.push("IGame");
        this.types.push("IObjectCollection");
        this.types.push("ISelfStart");
        this.types.push("IAddAction");
        this.types.push("ISelfLoad");
        this.types.push("IExternalAction");
        this.types.push("IResourceCollection");
        this.types.push("AbstractGame");
        this.typeName = "AbstractGame";
        if (factory != undefined) {
            factory.addFactory(new GameDetector_1.GameDetector(this, factory), "IGameDetector");
        }
        this.useLoader = useLoader;
        if (useLoader) {
            this.loader = new Loader_1.default();
            if (factory != undefined) {
                let loadFact = this.performer.createFactory(this.loader, factory);
                factory.addFactory(loadFact, "IResourceFuncFactory");
            }
        }
    }
    addAction(action, add) {
        this.actionF = action;
        this.addF = add;
    }
    getExternalAction() {
        return this.externalAction;
    }
    getResources() {
        return this.resources;
    }
    isRunning() {
        return this.isStarted;
    }
    addScene(name, scene) {
        this.scenes.set(name, scene);
        this.objects.push(scene);
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
    getScenes() {
        return this.scenes;
    }
    cycle(time) {
        this.internaTimeAction.actionT(time);
        this.externalAction.action();
        this.intAct.action();
        this.timeAction.actionT(time);
        this.internalAction.action();
    }
    getObjectCollection() {
        return this.objects;
    }
    setConsumerFactory(factory) {
        super.setConsumerFactory(factory);
        this.performer.setFactoryToObjectCollection(this, factory);
    }
    startItself(start) {
        if (this.isStarted == start)
            return false;
        this.isStarted = start;
        this.performer.startCollecion(start, this);
        this.intAct.clearActions();
        this.internaTimeAction.clearActionsT();
        for (var scene of this.scenes) {
            let sc = scene[1];
            this.intAct.addAction(sc.getExternalAction());
            this.internaTimeAction.addActionT(sc);
        }
        return true;
    }
    loadItself(load) {
        if (this.isLoaded == load)
            return false;
        this.isLoaded = load;
        if (load) {
            if (this.loader != undefined) {
                this.loadProtected();
                return true;
            }
        }
        this.performer.loadCollecion(load, this);
        this.internalAction.clearActions();
        if (load) {
            this.performer.collectResources(this, this);
            for (var s of this.scenes) {
                this.internalAction.addAction(s[1].getInternalAction());
            }
        }
        return true;
    }
    addChildT(child) {
        this.children.push(child);
        this.objects.push(child);
        var name = child.getName();
        if (!this.scenes.has(name)) {
            this.scenes.set(name, child);
        }
    }
    removeChildT(child) {
        this.performer.remove(this.children, child);
    }
    getChildernT() {
        return this.children;
    }
    async loadProtected() {
        this.resourcesI.clear();
        this.performer.collectResources(this, this);
        this.performer.convertResourceInfo(this.resources, this.resourcesI);
        this.loader.loadMap(this.resourcesI);
        await this.loader.wait();
        this.performer.loadCollecion(true, this);
        this.internalAction.clearActions();
        this.performer.collectResources(this, this);
        for (var s of this.scenes) {
            this.internalAction.addAction(s[1].getInternalAction());
        }
        this.onLoad.action();
    }
    addPostLoadAction(action) {
        this.onLoad.addAction(action);
    }
    getTimeAction() {
        return this.timeAction;
    }
    addTimeAction(action, add) {
        if (add) {
            this.timeAction.addActionT(action);
            return;
        }
        this.timeAction.removeActionT(action);
    }
    shouldStartAfterLoad() {
        const a = new StartAfrerLoad(this);
        this.addPostLoadAction(a);
    }
}
exports.AbstractGame = AbstractGame;
class StartAfrerLoad {
    constructor(game) {
        this.game = game;
    }
    action() {
        this.game.startItself(true);
    }
    isEmptyAction() {
        return false;
    }
}
//# sourceMappingURL=AbstractGame.js.map