"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Desktop = void 0;
class Desktop {
    constructor() {
        this.check = () => {
            return false;
        };
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