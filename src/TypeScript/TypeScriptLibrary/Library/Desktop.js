"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Desktop = void 0;
class Desktop {
    constructor() {
        this.objects = [];
        this.arrows = [];
    }
    getObjects() {
        return this.objects;
    }
    getArrows() {
        return this.arrows;
    }
    addObject(obj) {
        this.objects.push(obj);
    }
    addArrow(arr) {
        this.arrows.push(arr);
    }
    getName() {
        return this.name;
    }
}
exports.Desktop = Desktop;
//# sourceMappingURL=Desktop.js.map