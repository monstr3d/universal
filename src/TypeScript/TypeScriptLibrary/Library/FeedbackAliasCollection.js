"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FeedbackAliasCollection = void 0;
const FeedbackAlias_1 = require("./FeedbackAlias");
const FeedbackCollection_1 = require("./FeedbackCollection");
const FictiveDesktop_1 = require("./Fiction/FictiveDesktop");
const FictiveMeasurements_1 = require("./Fiction/FictiveMeasurements");
class FeedbackAliasCollection extends FeedbackCollection_1.FeedbackCollection {
    constructor(map, measurements, obj) {
        super(map);
        this.desktop = new FictiveDesktop_1.FictiveDesktop();
        this.measurements = new FictiveMeasurements_1.FictiveMeasurements();
        this.desktop = obj.getDesktop();
        this.measurements = measurements;
        this.fillFeedBackAliases();
    }
    fillFeedBackAliases() {
        var measuremets = this.performer.getMeasurementsMap(this.measurements);
        for (const [key, val] of this.map.entries()) {
            var an = this.performer.getAliasName(this.desktop, val);
            var m = measuremets.get(key);
            var iv = m;
            var alias = new FeedbackAlias_1.FeedbackAlias(an, iv);
            this.addFeedback(alias);
        }
    }
}
exports.FeedbackAliasCollection = FeedbackAliasCollection;
//# sourceMappingURL=FeedbackAliasCollection.js.map