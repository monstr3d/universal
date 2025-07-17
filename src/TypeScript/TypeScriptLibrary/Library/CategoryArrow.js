"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CategoryArrow = void 0;
class CategoryArrow {
    constructor(desktop, name) {
        this.desktop = desktop;
        this.name = name;
        desktop.addArrow(this);
    }
    getDesktop() {
        return this.desktop;
    }
    getName() {
        return this.name;
    }
    getSource() {
        return this.source;
    }
    getTagret() {
        return this.target;
    }
    setSource(source) {
        this.source = source;
    }
    setTarget(target) {
        this.target = target;
    }
}
exports.CategoryArrow = CategoryArrow;
class FictiveCategoryArrow {
    getSource() {
        throw new Error("Method not implemented.");
    }
    getTagret() {
        throw new Error("Method not implemented.");
    }
    setSource(source) {
        throw new Error("Method not implemented.");
    }
    setTarget(target) {
        throw new Error("Method not implemented.");
    }
    getName() {
        throw new Error("Method not implemented.");
    }
    getDesktop() {
        throw new Error("Method not implemented.");
    }
}
//# sourceMappingURL=CategoryArrow.js.map