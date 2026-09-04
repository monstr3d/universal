"use strict";
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
Object.defineProperty(exports, "__esModule", { value: true });
exports.CategoryArrow = void 0;
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
const EmptyObject_1 = require("./EmptyObject");
const Performer_1 = require("./Performer");
class CategoryArrow extends EmptyObject_1.EmptyObject {
    constructor(desktop, name) {
        super(name);
        this.typeName = "CategoryArrow";
        this.types.push("ICategoryArrow");
        this.types.push("CategoryArrow");
        this.desktop = desktop;
        this.name = name;
        desktop.addCategoryArrow(this);
        desktop.addObject(this);
    }
    desktop;
    source;
    target;
    performer = new Performer_1.Performer();
    getDesktop() {
        return this.desktop;
    }
    getArrowName() {
        return this.name;
    }
    getSource() {
        return this.source;
    }
    getTarget() {
        return this.target;
    }
    setSource(source) {
        this.source = source;
    }
    setTarget(target) {
        this.target = target;
    }
    getObjectT(s, type) {
        return this.performer.convertObject(s, type);
    }
}
exports.CategoryArrow = CategoryArrow;
