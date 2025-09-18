"use strict";
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
Object.defineProperty(exports, "__esModule", { value: true });
exports.ObjectTransformerLink = void 0;
const CategoryArrow_1 = require("../../CategoryArrow");
class ObjectTransformerLink extends CategoryArrow_1.CategoryArrow {
    constructor(desktop, name) {
        super(desktop, name);
        this.typeName = "ObjectTransformerLink";
        this.types.push("ObjectTransformerLink");
    }
    getSource() {
        return this.consumer;
    }
    getTagret() {
        return this.transformer;
    }
    setSource(source) {
        this.consumer = source;
    }
    setTarget(target) {
        this.transformer = target;
        this.consumer.addTransformer(this.transformer);
    }
    getName() {
        return this.name;
    }
}
exports.ObjectTransformerLink = ObjectTransformerLink;
//# sourceMappingURL=ObjectTransformerLink.js.map