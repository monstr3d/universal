"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ScadaFindCamera = void 0;
const AbstractGameObject_1 = require("../../Game/Abstract/AbstractGameObject");
class ScadaFindCamera extends AbstractGameObject_1.AbstractGameObject {
    functT(s) {
        var sc = this.performer.sceneToScada(s);
        if (sc === undefined)
            return undefined;
        var ob = sc.getScadaObject(this.name, "BasicCamera");
        if (ob.length > 0)
            return ob[0];
        return undefined;
    }
    constructor(name) {
        super(name, undefined);
        this.types.push("IFindCamera");
        this.types.push("ScadaFindCamera");
        this.typeName = "ScadaFindCamera";
    }
}
exports.ScadaFindCamera = ScadaFindCamera;
//# sourceMappingURL=ScadaFindCamera.js.map