"use strict";
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
Object.defineProperty(exports, "__esModule", { value: true });
exports.Desktop = void 0;
const OwnNotImplemented_1 = require("./ErrorHandler/OwnNotImplemented");
class Desktop {
    constructor() {
        this.categoryObjects = [];
        this.categoryArrows = [];
        this.objects = [];
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
    getCategoryObject(name) {
        for (var o of this.categoryObjects) {
            var n = o.getCategoryObjectName();
            if (n == name) {
                return o;
            }
        }
        throw new OwnNotImplemented_1.OwnNotImplemented();
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