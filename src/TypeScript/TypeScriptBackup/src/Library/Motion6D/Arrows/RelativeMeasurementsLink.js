"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RelativeMeasurementsLink = void 0;
const CategoryArrow_1 = require("../../CategoryArrow");
const OwnError_1 = require("../../ErrorHandler/OwnError");
class RelativeMeasurementsLink extends CategoryArrow_1.CategoryArrow {
    constructor(desktop, name) {
        super(desktop, name);
        this.typeName = "RelativeMeasurementsLink";
        this.types.push("RelativeMeasurementsLink");
    }
    getRelativeMeasurerements() {
        let rs = this.performer.convertObject(this.source, "RelativeMeasurements");
        if (rs.length > 0) {
            return rs;
        }
        let rt = this.performer.convertObject(this.target, "RelativeMeasurements");
        if (rt.length > 0) {
            return rt;
        }
        return [];
    }
    getSourceObject(obj) {
        var rm = this.performer.convertObject(obj, "RelativeMeasurements");
        if (rm.length > 0) {
            var r = rm[0];
            if (r.getClassName() == "RelativeMeasurements") {
                return r;
            }
        }
        let rp = this.performer.convertObject(obj, "IPosition");
        if (rp.length > 0) {
            return obj;
        }
        throw new OwnError_1.OwnError("Illegal type", "", "");
    }
    setSource(source) {
        this.source = this.getSourceObject(source);
    }
    setTarget(target) {
        this.target = target;
        let sr = this.performer.convertObject(this.source, "IPosition");
        let m = this.getRelativeMeasurerements();
        if (m.length > 0) {
            if (sr.length > 0) {
                m[0].setSource(sr[0]);
                return;
            }
        }
        m[0].setTaget(sr[0]);
    }
}
exports.RelativeMeasurementsLink = RelativeMeasurementsLink;
//# sourceMappingURL=RelativeMeasurementsLink.js.map