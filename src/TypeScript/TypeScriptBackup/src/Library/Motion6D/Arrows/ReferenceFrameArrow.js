"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ReferenceFrameArrow = void 0;
const CategoryArrow_1 = require("../../CategoryArrow");
class ReferenceFrameArrow extends CategoryArrow_1.CategoryArrow {
    constructor(desktop, name) {
        super(desktop, name);
        this.typeName = "ReferenceFrameArrow";
        this.types.push("ReferenceFrameArrow");
    }
    getSource() {
        return this.position;
    }
    getTagret() {
        return this.frame;
    }
    setSource(source) {
        this.position = source;
        this.positionNode = this.position;
    }
    setTarget(target) {
        let f = target;
        this.frame = f;
        let p = f;
        if (p === undefined) { }
        else {
            p.addNodeT(this.positionNode);
        }
        this.position.setParentFrame(f);
    }
}
exports.ReferenceFrameArrow = ReferenceFrameArrow;
//# sourceMappingURL=ReferenceFrameArrow.js.map