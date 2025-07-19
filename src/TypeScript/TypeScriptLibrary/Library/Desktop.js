"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Desktop = void 0;
class Desktop {
    constructor() {
        this.check = () => {
            return true;
        };
        this.objects = [];
        this.arrows = [];
    }
    setCheck(check) {
        this.check = check;
    }
    getCheck() {
        return this.check;
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