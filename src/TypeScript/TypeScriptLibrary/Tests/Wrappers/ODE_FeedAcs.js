"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ODE_FeedAct = void 0;
const RungeProcessor_1 = require("../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor");
const PefrormerMeasuremets_1 = require("../../Library/Measurements/PefrormerMeasuremets");
const Performer_1 = require("../../Library/Performer");
const DataRuntimeConsumerODE_1 = require("../../Library/Runtime/DataRuntimeConsumerODE");
const ODE_Feed_1 = require("../ODE_Feed");
class ODE_FeedAct extends ODE_Feed_1.ODE_Feed {
    constructor() {
        super();
        this.performer = new Performer_1.Performer();
        this.dc = this.getCategoryObject("Chart");
    }
    action() {
        this.performer.print(this.dc);
    }
    func() {
        return false;
    }
    test() {
        try {
            let processor = new RungeProcessor_1.RungeProcessor();
            var runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, processor);
            var p = new PefrormerMeasuremets_1.PefrormerMeasuremets();
            p.performFixedStepCalculation(runtime, 0, 0.1, 30, this, this);
        }
        catch (e) {
            let i = 0;
            //    throw new OwnNotImplemented();
        }
    }
}
exports.ODE_FeedAct = ODE_FeedAct;
//# sourceMappingURL=ODE_FeedAcs.js.map