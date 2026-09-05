"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DrawMeshActionConverter = void 0;
const AbstractGameAcionConverter_1 = require("../../Game/GameActions/AbstractGameAcionConverter");
const ActionArray_1 = require("../../Utilities/Generic/ActionArray");
const Game3DPerformer_1 = require("../Game3DPerformer");
class DrawMeshActionConverter extends AbstractGameAcionConverter_1.AbstractGameAcionConverter {
    constructor(drawMesh) {
        super();
        this.game3DPerformer = new Game3DPerformer_1.Game3DPerformer();
        this.types.push("IGameAcionConverter");
        this.types.push("DrawMeshActionConverter");
        this.typeName = "DrawMeshActionConverter";
        this.drawMesh = drawMesh;
    }
    functT(s) {
        let act = new ActionArray_1.ActionArray();
        act.addAction(s);
        var ob = s;
        var p = this.game3DPerformer.detectMeshFrame(ob);
        if (p == undefined) {
            return s;
        }
        return s;
    }
}
exports.DrawMeshActionConverter = DrawMeshActionConverter;
//# sourceMappingURL=DrawMeshActionConverter.js.map