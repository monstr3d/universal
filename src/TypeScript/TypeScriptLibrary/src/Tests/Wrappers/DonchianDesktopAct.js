"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DonchianDesktopAct = void 0;
const PerformerMeasuremets_1 = require("../../Library/Measurements/PerformerMeasuremets");
const Performer_1 = require("../../Library/Performer");
const DataRuntimeConsumer_1 = require("../../Library/Runtime/DataRuntimeConsumer");
const DonchianDesktop_1 = require("../DonchianDesktop");
class DonchianDesktopAct extends DonchianDesktop_1.DonchianDesktop {
    dc;
    constructor() {
        super();
        this.dc = this.performer.getByType(this, "DataConsumer")[0];
    }
    isEmptyAction() {
        return false;
    }
    func() {
        return false;
    }
    action() {
        this.performer.print(this.dc);
    }
    performer = new Performer_1.Performer();
    test() {
        var runtime = new DataRuntimeConsumer_1.DataRuntimeConsumer(this.dc, this.factory);
        var p = new PerformerMeasuremets_1.PerformerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 0.1, 5, this, this);
    }
}
exports.DonchianDesktopAct = DonchianDesktopAct;
