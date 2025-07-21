"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CategoryObject = void 0;
const Performer_1 = require("./Performer");
class CategoryObject {
    constructor(desktop, name) {
        this.performer = new Performer_1.Performer();
        this.desktop = desktop;
        this.name = name;
        desktop.addObject(this);
        this.checker = desktop.getCheck();
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
    getName() {
        return this.name;
    }
    check(x) {
        return this.checker(x);
    }
}
exports.CategoryObject = CategoryObject;
//# sourceMappingURL=CategoryObject.js.map