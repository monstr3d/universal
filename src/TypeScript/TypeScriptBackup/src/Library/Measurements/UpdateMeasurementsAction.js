"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.UpdateMeasurementsAction = void 0;
class UpdateMeasurementsAction {
    action() {
        this.m.updateMeasurements();
    }
    isEmptyAction() { return false; }
    constructor(m) {
        this.m = m;
    }
}
exports.UpdateMeasurementsAction = UpdateMeasurementsAction;
//# sourceMappingURL=UpdateMeasurementsAction.js.map