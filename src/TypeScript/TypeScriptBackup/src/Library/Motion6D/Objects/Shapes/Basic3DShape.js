"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Basic3DShape = void 0;
const CategoryObject_1 = require("../../../CategoryObject");
class Basic3DShape extends CategoryObject_1.CategoryObject {
    constructor(desktop, name) {
        super(desktop, name);
        this.resources = [];
        this.grahicalData = new Map();
        this.size = [[0, 0, 0], [0, 0, 0], [0, 0, 0],];
        this.typeName = "Basic3DShape";
        this.types.push("Basic3DShape");
        this.types.push("IVisible");
        this.types.push("IPositionObject");
        this.types.push("ISaveGrahicalData");
        this.types.push("IStartPrimitive");
    }
    getResources() {
        return this.resources;
    }
    startPrimitive() {
    }
    getSaveGrahicalData() {
        return this.grahicalData;
    }
    getVisibleSize() {
        return this.size;
    }
    setVisibleSize(size) {
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++) {
                this.size[i][j] = size[i][j];
            }
        }
    }
    addResource(name, url, type, ext) {
        let r = { name: name, type: type, ext: ext, url: url };
        this.resources.push(r);
    }
    getObjectPosition() {
        return this.position;
    }
    setObjectPosition(position) {
        this.position = position;
    }
}
exports.Basic3DShape = Basic3DShape;
//# sourceMappingURL=Basic3DShape.js.map