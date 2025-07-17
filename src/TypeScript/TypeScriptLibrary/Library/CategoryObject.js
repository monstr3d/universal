"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CategoryObject = void 0;
class CategoryObject {
    constructor(desktop, name) {
        this.desktop = desktop;
        this.name = name;
        desktop.addObject(this);
    }
    getDesktop() {
        return this.desktop;
    }
    getObject() {
        return this.obj;
    }
    setObject(obj) {
        this.obj = obj;
    }
    getName() {
        return this.name;
    }
}
exports.CategoryObject = CategoryObject;
class FictiveCategoryObject {
    getObject() {
        throw new Error("Method not implemented.");
    }
    setObject(obj) {
        throw new Error("Method not implemented.");
    }
    getName() {
        throw new Error("Method not implemented.");
    }
    getDesktop() {
        throw new Error("Method not implemented.");
    }
}
//# sourceMappingURL=CategoryObject.js.map