"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.MeasurementsComparator = void 0;
class MeasurementsComparator {
    constructor(performer) {
        this.performer = performer;
    }
    compare(x, y) {
        if (x == y) {
            return 0;
        }
        if (this.performer.implementsType(x, "IDataConsumer")) {
            var dcx = x;
            if (this.isSource(dcx, y)) {
                return 1;
            }
        }
        if (this.performer.implementsType(y, "IDataConsumer")) {
            var dcy = y;
            if (this.isSource(dcy, x)) {
                return -1;
            }
        }
        return 0;
    }
    isSource(dc, m) {
        var measurements = dc.getAllMeasurements();
        var count = measurements.length;
        for (var i = 0; i < count; i++) {
            var x = measurements[i];
            if (m == x) {
                return true;
            }
            if (this.performer.implementsType(x, "IDataConsumer")) {
                var dataConsumer = x;
                if (this.isSource(dataConsumer, m)) {
                    return true;
                }
            }
        }
        return false;
    }
}
exports.MeasurementsComparator = MeasurementsComparator;
//# sourceMappingURL=MeasurementsComparator.js.map