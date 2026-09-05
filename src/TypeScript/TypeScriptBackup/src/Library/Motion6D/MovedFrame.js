"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.MovedFrame = void 0;
const ReferenceFrame_1 = require("./ReferenceFrame");
class MovedFrame extends ReferenceFrame_1.ReferenceFrame {
    constructor() {
        super(...arguments);
        this.velocity = [0, 0, 0];
    }
    getVelocity() {
        return this.velocity;
    }
}
exports.MovedFrame = MovedFrame;
//# sourceMappingURL=MovedFrame.js.map