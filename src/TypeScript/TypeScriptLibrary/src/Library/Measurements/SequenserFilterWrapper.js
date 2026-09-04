"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SequenceFilterWrapper = void 0;
const AverageSequenceFilter_1 = require("../Utilities/Filters/AverageSequenceFilter");
const DonchianSequenceFilter_1 = require("../Utilities/Filters/DonchianSequenceFilter");
const SequenceFilterType_1 = require("../Utilities/Filters/Interfaces/SequenceFilterType");
const DataConsumerMeasurements_1 = require("./DataConsumerMeasurements");
class SequenceFilterWrapper extends DataConsumerMeasurements_1.DataConsumerMeasurements {
    type = SequenceFilterType_1.SequenceFilterType.Avarage;
    mimax = true;
    count;
    input;
    result = undefined;
    measurement;
    filter = new DonchianSequenceFilter_1.DonchianSequenceFilter(2, true);
    constructor(desktop, name) {
        super(desktop, name);
        this.types.push("IMeasurement");
        this.types.push("SequenceFilterWrapper");
        this.typeName = "SequenceFilterWrapper";
    }
    getMeasurementsCount() {
        return 1;
    }
    getMeasurement(i) {
        this.ficI = i;
        return this;
    }
    ficI = 0;
    getMeasurementName() {
        return "Output";
    }
    getMeasurementType() {
        return 0;
    }
    getMeasurementValue() {
        return this.result;
    }
    updateMeasurements() {
        // this.performer.updateChildrenData(this);
        var x = this.measurement.getMeasurementValue();
        if (this.checker.check(x)) {
            this.result = undefined;
            return;
        }
        if (typeof x === 'number') {
            var a = Number(x);
            this.result = this.filter.getFilterValue(a);
        }
    }
    getFilter() {
        return this.filter;
    }
    setFilter() {
        if (this.type == SequenceFilterType_1.SequenceFilterType.Avarage) {
            this.filter = new AverageSequenceFilter_1.AverageSequenceFilter(this.count);
            return;
        }
        this.filter = new DonchianSequenceFilter_1.DonchianSequenceFilter(this.count, this.mimax);
    }
    setMeasurement() {
        this.measurement = this.performer.getMeasurementDC(this, this.input);
    }
    postSetArrow() {
        this.setFilter();
        this.setMeasurement();
    }
}
exports.SequenceFilterWrapper = SequenceFilterWrapper;
