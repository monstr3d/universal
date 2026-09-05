"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractGameObject = void 0;
const GamePerformer_1 = require("../GamePerformer");
class AbstractGameObject {
    constructor(name, factory) {
        this.performer = new GamePerformer_1.GamePerformer();
        this.typeName = "AbstactGameObject";
        this.types = ["IObject", "IFactoryConsumer", "AbstactGameObject"];
        this.name = "";
        this.name = name;
        this.setFactory(factory);
    }
    setConsumerFactory(factory) {
        this.setFactory(factory);
    }
    getConsumerFactory() {
        return this.factory;
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
    setFactory(factory) {
        if (factory == null)
            return;
        this.factory = factory;
        this.detectShow();
    }
    detectShow() {
        if (this.showObj != undefined)
            return;
        const sh = this.factory.getFactory("IShowObject");
        if (sh != undefined)
            this.showObj = sh;
    }
    showObject(sender, object, name) {
        if (this.showObj == undefined)
            return;
        this.showObj.show(sender, object, name);
    }
}
exports.AbstractGameObject = AbstractGameObject;
//# sourceMappingURL=AbstractGameObject.js.map