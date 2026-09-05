"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Game3DPerformer = void 0;
const GamePerformer_1 = require("../Game/GamePerformer");
const Motion6DPerformer_1 = require("../Motion6D/Motion6DPerformer");
class Game3DPerformer extends GamePerformer_1.GamePerformer {
    constructor() {
        super(...arguments);
        this.pefrormer = new Motion6DPerformer_1.Motion6DPerformer();
    }
    getRelativeFrame(baseFrame, targetFrame, relative) {
        this.pefrormer.getRelativeFrame(baseFrame, targetFrame, relative);
    }
    detectMeshFrame(obj) {
        let r = obj;
        if (r === undefined) {
            return undefined;
        }
        var o = r.getActionSceneObject();
        var mh = o;
        if (mh != undefined) {
            var add = r.getActionSceneAdditionalObject();
            var rf = add;
            if (rf != undefined) {
                return { mesh: mh.getHolderMeshes(), frame: rf };
            }
        }
    }
    setInvertedCoorfinates(x, z, frame) {
        let m = frame.getMatrix();
        for (var i = 0; i < 3; i++) {
            x[i] = 0;
            for (var j = 0; j < 3; j++) {
                x[i] += m[j][i] * z[j];
            }
        }
        let y = frame.getPosition();
        for (var i = 0; i < 3; i++) {
            x[i] -= y[i];
        }
    }
    setInvertedCoorfinates2(xx, zz, frame) {
        let m = frame.getMatrix();
        let y = frame.getPosition();
        for (var k = 0; k < xx.length; k++) {
            let x = xx[k];
            let z = zz[k];
            for (var i = 0; i < 3; i++) {
                x[i] = 0;
                for (var j = 0; j < 3; j++) {
                    x[i] += m[j][i] * z[j];
                }
            }
            for (var i = 0; i < 3; i++) {
                x[i] -= y[i];
            }
        }
    }
    getOwnFrame(object) {
        var pos = this.convertObject(object, "IPosition");
        if (pos.length > 0) {
            return this.pefrormer.getOwnFrame(pos[0]);
        }
        var po = this.convertObject(object, "IPositionObject");
        if (po.length > 0) {
            var position = po[0].getObjectPosition();
            return this.pefrormer.getOwnFrame(position);
        }
        var ao = this.convertObject(object, "IAssociatedObject");
        {
            if (ao.length > 0)
                return this.getOwnFrame(ao[0].getAssociatedObject());
        }
        return undefined;
    }
}
exports.Game3DPerformer = Game3DPerformer;
//# sourceMappingURL=Game3DPerformer.js.map