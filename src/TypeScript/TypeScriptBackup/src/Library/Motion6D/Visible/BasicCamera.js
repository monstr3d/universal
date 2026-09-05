"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.BasicCamera = void 0;
const BasicPosition_1 = require("../Objects/BasicPosition");
class BasicCamera extends BasicPosition_1.BasicPosition {
    constructor(desktop, name) {
        super(desktop, name);
        this.visible = [];
        this.fieldOfView = 0;
        this.nearDistance = 0;
        this.farDistance = 0;
        this.typeName = "BasicCamera";
        this.types.push("IVisibleConsumer");
        this.types.push("ICamera");
        this.types.push("BasicCamera");
    }
    getCameraType() {
        return 'perspective';
    }
    getFieldOfView() {
        return this.fieldOfView;
    }
    getNearDistance() {
        return this.nearDistance;
    }
    getFarDistance() {
        return this.farDistance;
    }
    addVisibleObject(object) {
        this.visible.push(object);
    }
    removeVisibleObject(object) {
        this.performer.remove(this.visible, object);
    }
}
exports.BasicCamera = BasicCamera;
//# sourceMappingURL=BasicCamera.js.map