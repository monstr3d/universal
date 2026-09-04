"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ODE_FeedAct = void 0;
const RungeProcessor_1 = require("../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor");
const PerformerMeasuremets_1 = require("../../Library/Measurements/PerformerMeasuremets");
const Motion6DFactory_1 = require("../../Library/Motion6D/Motion6DFactory");
const Performer_1 = require("../../Library/Performer");
const DataRuntimeConsumerODE_1 = require("../../Library/Runtime/DataRuntimeConsumerODE");
const ODE_Feed_1 = require("../ODE_Feed");
class ODE_FeedAct extends ODE_Feed_1.ODE_Feed {
    dc;
    constructor() {
        super();
        this.dc = this.getCategoryObject("Chart");
    }
    isEmptyAction() {
        return false;
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
            var runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, new Motion6DFactory_1.Motion6DFactory());
            var p = new PerformerMeasuremets_1.PerformerMeasuremets();
            p.performFixedStepCalculation(runtime, 0, 0.1, 30, this, this);
        }
        catch (e) {
            let i = 0;
            //    throw new OwnNotImplemented();
        }
    }
    performer = new Performer_1.Performer();
}
exports.ODE_FeedAct = ODE_FeedAct;
