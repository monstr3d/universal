"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CategoryObject = void 0;
const Performer_1 = require("./Performer");
class CategoryObject {
    constructor(desktop, name) {
        this.types = ["IObject", "ICategoryObject", "CategoryObject"];
        this.typeName = "CategoryObject";
        this.performer = new Performer_1.Performer();
        this.desktop = desktop;
        this.name = name;
        desktop.addCategoryObject(this);
        desktop.addObject(this);
        this.checker = desktop.getCheck();
    }
    getName() {
        return this.name;
    }
    getClassName() {
        return this.typeName;
    }
    imlplementsType(type) {
        return this.types.indexOf(type) > 0;
    }
    convert(a) {
        return this.performer.convertFromAny(a);
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
    getCategoryObjectName() {
        return this.name;
    }
    check(x) {
        return this.checker(x);
    }
}
exports.CategoryObject = CategoryObject;
//# sourceMappingURL=CategoryObject.js.map