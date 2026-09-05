"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PositionComparer = void 0;
class PositionComparer {
    compare(x, y) {
        if (this.isSource(x, y))
            return -1;
        if (this.isSource(y, x))
            return 1;
        return 0;
    }
    isSource(source, target) {
        var tp = target.getParentFrame();
        if (tp === undefined) {
            return false;
        }
        if (tp == source) {
            return true;
        }
        if (this.isSource(source, tp)) {
            return true;
        }
        return false;
    }
}
exports.PositionComparer = PositionComparer;
//# sourceMappingURL=PositionComparer.js.map