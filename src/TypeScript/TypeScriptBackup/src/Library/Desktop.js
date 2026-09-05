"use strict";
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
Object.defineProperty(exports, "__esModule", { value: true });
exports.Desktop = void 0;
const OwnNotImplemented_1 = require("./ErrorHandler/OwnNotImplemented");
const Performer_1 = require("./Performer");
class Desktop {
    constructor(factory) {
        this.typeName = "Desktop";
        this.types = ["IObject", "IDesktop",
            "IComponentCollection", "IObjectCollection", "Desktop", "IFactoryConsumer"];
        this.categoryObjects = [];
        this.categoryArrows = [];
        this.objects = [];
        this.mapObjects = new Map();
        this.performer = new Performer_1.Performer();
        if (factory === undefined)
            return;
        this.factory = factory;
        let c = factory.getFactory("ICheck");
        if (c !== undefined)
            this.check = c;
    }
    imlplementsType(type) {
        return this.types.includes(type);
    }
    async initializeTaksAsync(cancel) {
        var init = [];
        var ii = this.performer.getByInterface(this, "IInitializeTask");
        for (var i of ii) {
            var k = i;
            let m = k.initializeTaskAsync(cancel);
            init.push(m);
        }
        await Promise.any(init);
    }
    async loadAsync(cancel) {
        await this.initializeTaksAsync(cancel);
        this.finish();
    }
    finish() {
    }
    getObjectCollection() {
        return this.objects;
    }
    addObject(obj) {
        this.objects.push(obj);
    }
    getObjects() {
        return this.objects;
    }
    setCheck(check) {
        this.check = check;
    }
    getCheck() {
        return this.check;
    }
    setConsumerFactory(factory) {
        this.factory = factory;
    }
    getConsumerFactory() {
        return this.factory;
    }
    getClassName() {
        return this.typeName;
    }
    getCategoryObject(name) {
        for (var o of this.categoryObjects) {
            var n = o.getCategoryObjectName();
            if (n == name) {
                return o;
            }
        }
        throw new OwnNotImplemented_1.OwnNotImplemented("DESKTOP");
    }
    getCategoryObjects() {
        return this.categoryObjects;
    }
    getCategoryArrows() {
        return this.categoryArrows;
    }
    addCategoryObject(obj) {
        this.categoryObjects.push(obj);
    }
    addCategoryArrow(arr) {
        this.categoryArrows.push(arr);
    }
    getName() {
        return this.name;
    }
}
exports.Desktop = Desktop;
//# sourceMappingURL=Desktop.js.map