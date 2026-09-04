"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.BasicCamera = void 0;
const BasicPosition_1 = require("../Objects/BasicPosition");
class BasicCamera extends BasicPosition_1.BasicPosition {
    constructor(desktop, name) {
        super(desktop, name);
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
    visible = [];
    fieldOfView = 0;
    nearDistance = 0;
    farDistance = 0;
}
exports.BasicCamera = BasicCamera;
