"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FactoryObject = void 0;
const EmptyObject_1 = require("./EmptyObject");
class FactoryObject extends EmptyObject_1.EmptyObject {
    constructor(name, factory) {
        super(name);
        this.types.push("IFactoryConsumer");
        this.types.push("FactoryObject");
        this.typeName = "FactoryObject";
        this.setFactory(factory);
    }
    setConsumerFactory(factory) {
        this.setFactory(factory);
    }
    getConsumerFactory() {
        return this.factory;
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
    setFactory(factory) {
        if (factory == null)
            return;
        this.factory = factory;
        this.detectShow();
    }
    factory;
    showObj;
}
exports.FactoryObject = FactoryObject;
