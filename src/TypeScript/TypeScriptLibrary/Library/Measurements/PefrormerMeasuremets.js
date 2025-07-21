"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PefrormerMeasuremets = void 0;
class PefrormerMeasuremets {
    getDependentPrivate(dataConsumer, measurements) {
        let m = dataConsumer.getAllMeasurements();
        for (let i = o; i < m.length; i++) {
            let mea = m[i];
            if (measurements.find(mea => true) === undefined) {
            }
            else {
                measurements.push(mea);
                if (mea instanceof IDataConsumer_1.IDataConsumer)
                    ;
            }
        }
    }
}
exports.PefrormerMeasuremets = PefrormerMeasuremets;
//# sourceMappingURL=PefrormerMeasuremets.js.map