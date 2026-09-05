"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.BelongsToCollection = void 0;
const CategoryArrow_1 = require("../CategoryArrow");
const OwnError_1 = require("../ErrorHandler/OwnError");
class BelongsToCollection extends CategoryArrow_1.CategoryArrow {
    constructor(desktop, name) {
        super(desktop, name);
        this.typeName = "BelongsToCollection";
        this.types.push("BelongsToCollection");
    }
    setSource(source) {
        this.source = source;
        let a = this.getObjectT(source, "IAddRemove");
        if (a.length == 0) {
            throw new OwnError_1.OwnError("BelongsToCollection", "setSource", "");
        }
        this.ar = a[0];
    }
    setTarget(target) {
        this.target = target;
        this.ar.addRemoveObject(target, true);
    }
}
exports.BelongsToCollection = BelongsToCollection;
//# sourceMappingURL=BelognsToCollection.js.map