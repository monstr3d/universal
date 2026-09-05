"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.UpdatePositionAction = void 0;
class UpdatePositionAction {
    constructor(position) {
        this.position = position;
    }
    action() {
        this.position.updateReferenceFrame();
    }
    isEmptyAction() { return false; }
}
exports.UpdatePositionAction = UpdatePositionAction;
//# sourceMappingURL=UpdatePositionAction.js.map