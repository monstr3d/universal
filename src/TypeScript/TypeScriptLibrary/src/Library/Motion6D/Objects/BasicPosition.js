"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.BasicPosition = void 0;
const CategoryObject_1 = require("../../CategoryObject");
const Performer_1 = require("../../Performer");
class BasicPosition extends CategoryObject_1.CategoryObject {
    /// <summary>
    /// Absolute position
    /// </summary>
    position = [0, 0, 0];
    /// <summary>
    /// Absolute position
    /// </summary>
    own = [0, 0, 0];
    /// <summary>
    /// Parent frame
    /// </summary>
    parent;
    parentNode;
    parameters;
    performer = new Performer_1.Performer();
    constructor(desktop, name) {
        super(desktop, name);
        this.typeName = "BasicPosition";
        this.types.push("IPosition");
        this.types.push("BasicPosition");
    }
    getPosition() {
        return this.position;
    }
    getParentFrame() {
        return this.parent;
    }
    setParentFrame(parent) {
        this.parent = parent;
    }
    getParameters() {
        return this.parameters;
    }
    setParameters(parameters) {
        this.parameters = parameters;
    }
    updateReferenceFrame() {
        var f = this.getBaseFrame();
        if (f === undefined)
            return;
        this.udateFrameProtected(f);
    }
    getParentT() {
        return this.parentNode;
    }
    setParentT(parent) {
        this.parentNode = parent;
    }
    getNodesT() {
        return this.nodes;
    }
    addNodeT(node) {
        this.current = node;
    }
    removeNodeT(node) {
        this.current = node;
    }
    getNodeValueT() {
        return this;
    }
    current;
    nodes = [];
    udateFrameProtected(frame) {
        let m = frame.getMatrix();
        let p = frame.getPosition();
        for (let i = 0; i < 3; i++) {
            this.position[i] = p[i];
            for (let j = 0; j < 3; j++) {
                this.position[i] += m[i][j] * this.own[j];
            }
        }
    }
    getBaseFrame() {
        if (this.parent == undefined) {
            return undefined;
        }
        return this.parent.getOwnFrame();
    }
}
exports.BasicPosition = BasicPosition;
