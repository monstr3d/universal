"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ScadaFind3dFrame = void 0;
const AbstractFindFrame_1 = require("./AbstractFindFrame");
class ScadaFind3dFrame extends AbstractFindFrame_1.AbstractFindFrame {
    constructor(name) {
        super(name);
        this.types.push("ScadaFindFrame");
        this.typeName = "ScadaFindFrame";
    }
    functT(s) {
        var sc = this.performer.sceneToScada(s);
        if (sc === undefined)
            return undefined;
        var ob = sc.getScadaObject(this.name, "IPosition");
        if (ob.length > 0) {
            var p = ob[0];
            var rf = this.performer.convertObject(p, "IReferenceFrame");
            if (rf.length > 0)
                return rf[0];
            return p.getParentFrame();
        }
        return undefined;
    }
}
exports.ScadaFind3dFrame = ScadaFind3dFrame;
//# sourceMappingURL=ScadaFind3DFrame.js.map