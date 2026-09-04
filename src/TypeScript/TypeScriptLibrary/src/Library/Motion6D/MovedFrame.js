"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.MovedFrame = void 0;
const ReferenceFrame_1 = require("./ReferenceFrame");
class MovedFrame extends ReferenceFrame_1.ReferenceFrame {
    getVelocity() {
        return this.velocity;
    }
    velocity = [0, 0, 0];
}
exports.MovedFrame = MovedFrame;
