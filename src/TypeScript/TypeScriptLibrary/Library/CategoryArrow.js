"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CategoryArrow = void 0;
class CategoryArrow {
    constructor(desktop, name) {
        this.typeName = "CategoryArrow";
        this.types = ["ICategoryArrow", "CategoryArrow"];
        this.desktop = desktop;
        this.name = name;
        desktop.addCategoryArrow(this);
        desktop.addObject(this);
    }
    getClassName() {
        return this.typeName;
    }
    imlplementsType(type) {
        return this.types.indexOf(type) >= 0;
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
//# sourceMappingURL=CategoryArrow.js.map