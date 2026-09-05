"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RigidReferenceFrame = void 0;
const CategoryObject_1 = require("../../CategoryObject");
const OwnError_1 = require("../../ErrorHandler/OwnError");
const Motion6DAcceleratedFrame_1 = require("../Motion6DAcceleratedFrame");
const Motion6DPerformer_1 = require("../Motion6DPerformer");
const ReferenceFrame_1 = require("../ReferenceFrame");
const Motion6DFrame_1 = require("../Motion6DFrame");
const RotatedFrame_1 = require("../RotatedFrame");
const MovedFrame_1 = require("../MovedFrame");
const RealMatrix_1 = require("../../RealMatrixProcessor/RealMatrix");
const Vector3DProcessor_1 = require("../../Vector3D/Vector3DProcessor");
const PerformerMeasuremets_1 = require("../../Measurements/PerformerMeasuremets");
class RigidReferenceFrame extends CategoryObject_1.CategoryObject {
    constructor(desktop, name) {
        super(desktop, name);
        /// </summary>
        this.relativePosition = [0, 0, 0];
        /// <summary> : IFunc<any>[] = [];
        /// Relarive quaternion components
        /// </summary>
        this.relativeQuaternion = [1, 0, 0, 0];
        this.children = [];
        //protected double[,] relativeMatrix = new double[3, 3];
        /// <summary>
        /// Auxiliary variable
        /// </summary>
        this.q44 = [[0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0]];
        /// <summary>
        /// Linear velocity
        /// </summary>
        this.velocity = [0, 0, 0, 0];
        // protected double[] relativeVelocity = new double[] { 0, 0, 0 };
        /// <summary>
        /// Angular velocity
        /// </summary>
        this.omega = [0, 0, 0];
        this.aliasNames = ["X", "Y", "Z", "Roll", "Pitch", "Yaw"];
        this.alinames = new Map();
        this.vp = new Vector3DProcessor_1.Vector3DProcessor();
        this.realMatrix = new RealMatrix_1.RealMatrix();
        this.own = new Motion6DAcceleratedFrame_1.Motion6DAcceleratedFrame();
        this.relative = new Motion6DAcceleratedFrame_1.Motion6DAcceleratedFrame();
        this.mPerformer = new Motion6DPerformer_1.Motion6DPerformer();
        this.measuremrntPerformrer = new PerformerMeasuremets_1.PerformerMeasuremets();
        this.nodes = [];
        this.typeName = "RigidReferenceFrame";
        this.types.push("IReferenceFrame");
        this.types.push("IPosition");
        this.types.push("IPostLoadPosition");
        this.types.push("IPostSetArrow");
        this.types.push("IAlias");
        this.types.push("RigidReferenceFrame");
    }
    postSetArrow() {
        this.setParameters(this.parameters);
        this.createFrame();
        this.relative.copyReferenceFrameFromPositionQuatetnion(this.relativePosition, this.relativeQuaternion);
        this.own.copyReferenceFrameFromPositionQuatetnion(this.relativePosition, this.relativeQuaternion);
    }
    getAliasNames() {
        return this.aliasNames;
    }
    getAliasType(name) {
        this.any = name;
        return 0;
    }
    getAliasValue(name) {
        return this.alinames.get(name);
    }
    setAliasValue(name, value) {
        this.alinames.set(name, value);
    }
    postLoadPosition() {
        this.createFrame();
        this.copyPositionToRelativeFrame();
        this.copyQuaternionToRelativeFrame();
        this.init();
        this.relative.setMatrix();
    }
    impl(s) {
        if (this.parent === undefined) {
            return true;
        }
        var own = this.parent.getOwnFrame();
        if (own === undefined) {
            return false;
        }
        return this.performer.implementsType(own, s);
    }
    isAcceleration() {
        return this.impl("IAcceleration");
    }
    isVelocity() {
        return this.impl("IVelocity");
    }
    isAngularVelocity() {
        return this.impl("IAngularVelocity");
    }
    copyPositionToRelativeFrame() {
        var rp = this.relative.getPosition();
        this.performer.copyArray(this.relativePosition, rp);
    }
    copyQuaternionToRelativeFrame() {
        var rp = this.relative.getQuaternion();
        this.performer.copyArray(this.relativeQuaternion, rp);
        this.relative.setMatrix();
    }
    copy6DPosition() {
        this.copyPositionToRelativeFrame();
        this.copyQuaternionToRelativeFrame();
    }
    init() {
        if (this.relative === undefined) {
            return;
        }
        let q = this.relative.getQuaternion();
        for (let i = 0; i < q.length; i++) {
            q[i] = this.relativeQuaternion[i];
        }
        var p = this.relative.getPosition();
        for (let i = 0; i < p.length; i++) {
            p[i] = this.relativePosition[i];
        }
    }
    createFrame() {
        if (this.isAcceleration()) {
            this.relative = new Motion6DAcceleratedFrame_1.Motion6DAcceleratedFrame();
            this.own = new Motion6DAcceleratedFrame_1.Motion6DAcceleratedFrame();
        }
        if (this.isVelocity() && this.isAngularVelocity()) {
            this.relative = new Motion6DFrame_1.Motion6DFrame();
            this.own = new Motion6DFrame_1.Motion6DFrame();
        }
        if (this.isAngularVelocity()) {
            this.relative = new RotatedFrame_1.RotatedFrame();
            this.own = new RotatedFrame_1.RotatedFrame();
        }
        if (this.isVelocity()) {
            this.relative = new MovedFrame_1.MovedFrame();
            this.own = new MovedFrame_1.MovedFrame();
        }
        this.relative = new ReferenceFrame_1.ReferenceFrame();
        this.own = new ReferenceFrame_1.ReferenceFrame();
    }
    getNodeValueT() {
        return this;
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
        this.nodes.push(node);
    }
    removeNodeT(node) {
        this.nodes = this.performer.remove(this.nodes, node);
    }
    getOwnFrame() {
        return this.own;
    }
    getPosition() {
        return this.own.getPosition();
    }
    getParentFrame() {
        return this.parent;
    }
    setParentFrame(parent) {
        if ((parent != undefined) && this.parent != undefined) {
            throw new OwnError_1.OwnError("Parent", "", "");
        }
        this.parent = parent;
        if (parent == undefined) {
            this.own = this.mPerformer.getBaseFrame();
            return;
        }
    }
    getParameters() {
        return this.parameters;
    }
    setParameters(parameters) {
        this.parameters = parameters;
    }
    updateReferenceFrame() {
        let own = this.getOwnFrame();
        let b = this.getBaseFrame();
        if (b === undefined) {
            this.relative.copyReferenceFrameFrom(own);
        }
        else {
            own.setReferenceFrame(b, this.relative);
        }
    }
    getBaseFrame() {
        if (this.parent === undefined) {
            return undefined;
        }
        else {
            return this.parent.getOwnFrame();
        }
    }
}
exports.RigidReferenceFrame = RigidReferenceFrame;
//# sourceMappingURL=RigidReferenceFrame.js.map