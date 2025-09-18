"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FeedbackAliasCollection = void 0;
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
const FeedbackAlias_1 = require("./FeedbackAlias");
const FeedbackCollection_1 = require("./FeedbackCollection");
class FeedbackAliasCollection extends FeedbackCollection_1.FeedbackCollection {
    constructor(map, measurements, obj) {
        super(map);
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