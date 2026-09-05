"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ReferenceFrame = void 0;
const Performer_1 = require("../Performer");
const RealMatrix_1 = require("../RealMatrixProcessor/RealMatrix");
const Vector3DProcessor_1 = require("../Vector3D/Vector3DProcessor");
class ReferenceFrame {
    constructor() {
        this.nodes = [];
        this.performer = new Performer_1.Performer();
        this.realMatrix = new RealMatrix_1.RealMatrix();
        this.vp = new Vector3DProcessor_1.Vector3DProcessor();
        this.positions = [];
        this.types = ["IObject", "IOrientation", "IPosition", "ReferenceFrame"];
        this.typeName = "ReferenceFrame";
        this.quaternion = [1, 0, 0, 0];
        /// <summary>
        /// Absolute position
        /// </summary>
        this.position = [0, 0, 0];
        /// <summary>
        /// Orientation matrix
        /// </summary>
        this.matrix = [[1, 0, 0], [0, 1, 0], [0, 0, 1]];
        /// <summary>
        /// Auxiliary array
        /// </summary>
        this.qq = [[0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0]];
        /// <summary>
        /// Auxiliary array
        /// </summary>
        this.p = [0, 0, 0];
        /// <summary>
        /// Auxliary position
        /// </summary>
        this.auxPos = [0, 0, 0];
    }
    setParameters(parameters) {
        this.parameters = parameters;
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
    getNodeValueT() {
        return this;
    }
    copyReferenceFrameFromArrays(m, p) {
        var mm = this.matrix;
        for (var i = 0; i < m.length; i++) {
            var c = m[i];
            var cc = mm[i];
            for (var j = 0; j < cc.length; j++) {
                cc[j] = c[i];
            }
        }
        var pp = this.position;
        for (var i = 0; i < p.length; i++) {
            pp[i] = p[i];
        }
    }
    copyReferenceFrameFromPositionQuatetnion(position, quaternion) {
        var p = this.position;
        for (var i = 0; i < p.length; i++) {
            p[i] = position[i];
        }
        var q = this.quaternion;
        for (var i = 0; i < q.length; i++) {
            q[i] = quaternion[i];
        }
        this.setMatrix();
    }
    copyReferenceFrameFrom(frame) {
        this.copyReferenceFrameFromArrays(frame.matrix, frame.position);
    }
    setReferenceFrame(baseFrame, relative) {
        let m = baseFrame.getMatrix();
        var bp = baseFrame.getPosition();
        var rp = relative.getPosition();
        for (let i = 0; i < 3; i++) {
            this.position[i] = bp[i];
            for (let j = 0; j < 3; j++) {
                this.position[i] += m[i][j] * rp[j];
            }
        }
        this.vp.quaternionMultiply(baseFrame.quaternion, relative.quaternion, this.quaternion);
        this.setMatrix();
    }
    getQuaternion() {
        return this.quaternion;
    }
    getMatrix() {
        return this.matrix;
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
    updateReferenceFrame() {
        let p = this.getParentFrame();
        if (p === undefined) {
            return;
        }
        let r = p.getOwnFrame();
        if (r === undefined) {
            return;
        }
        this.position = r.getPosition();
        this.quaternion = r.getQuaternion();
        this.matrix = r.getMatrix();
    }
    getPositions() {
        return this.positions;
    }
    addPosition(position) {
        this.positions.push(position);
    }
    // new Error
    getClassName() {
        return this.typeName;
    }
    imlplementsType(type) {
        return this.types.indexOf(type) > 0;
    }
    getName() {
        return "";
    }
    getRelativePosition(inPosition, outPosition) {
        for (let i = 0; i < 3; i++) {
            this.auxPos[i] = inPosition[i] - this.position[i];
        }
        for (let i = 0; i < 3; i++) {
            outPosition[i] = 0;
            for (let j = 0; j < 3; j++) {
                outPosition[i] += this.matrix[j][i] * this.auxPos[j];
            }
        }
    }
    norm() {
        this.vp.quaternionNormalize(this.quaternion);
    }
    setMatrix() {
        this.norm();
        this.vp.quaternionToMatrix(this.quaternion, this.matrix, this.qq);
    }
    getPositionArray(position, coordinates) {
        let p1 = this.getPosition();
        let p2 = position.getPosition();
        for (let i = 0; i < 3; i++) {
            this.p[i] = p2[i] - p1[i];
        }
        for (let i = 0; i < 3; i++) {
            coordinates[i] = 0;
            for (let j = 0; j < 3; j++) {
                coordinates[i] += this.matrix[i][j] * this.p[j];
            }
        }
    }
    getRelative(baseFrame, relativeFrame, result, diff) {
        this.vp.quaternionInvertMultiply(relativeFrame.quaternion, baseFrame.quaternion, result.quaternion);
        result.setMatrix();
        for (let i = 0; i < 3; i++) {
            diff[i] = relativeFrame.position[i] - baseFrame.position[i];
        }
        let m = baseFrame.getMatrix();
        let p = result.getPosition();
        for (let i = 0; i < 3; i++) {
            p[i] = 0;
            for (let j = 0; j < 3; j++) {
                p[i] += m[j][i] * diff[j];
            }
        }
    }
    calculateRotatedPosition(abs, rot) {
        for (let i = 0; i < 3; i++) {
            rot[i] = 0;
            for (let j = 0; j < 3; j++) {
                rot[i] += this.matrix[j][i] * abs[j];
            }
        }
    }
}
exports.ReferenceFrame = ReferenceFrame;
//# sourceMappingURL=ReferenceFrame.js.map