"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataRuntimeConsumerMotion6DEvent = void 0;
const DataRuntimeConsumerEvent_1 = require("../../../Event/Runtime/DataRuntimeConsumerEvent");
const Motion6DPerformer_1 = require("../../Motion6DPerformer");
class DataRuntimeConsumerMotion6DEvent extends DataRuntimeConsumerEvent_1.DataRuntimeConsumerEvent {
    motionPeformer = new Motion6DPerformer_1.Motion6DPerformer();
    constructor(dataConsumer, factory) {
        super(dataConsumer, factory);
        if (this.motionPeformer === undefined) {
            this.motionPeformer = new Motion6DPerformer_1.Motion6DPerformer();
        }
    }
    prepare(dataConsumer) {
        super.prepare(dataConsumer);
        var ar = this.addRemove;
        for (var co of ar) {
            var fr = this.performer.convertObject(co, "IReferenceFrame");
            if (fr.length > 0) {
                if (!this.categoryObjects.includes(co)) {
                    this.categoryObjects.push(co);
                }
            }
        }
    }
    getExternalUpdate(obj, realime, act) {
        super.getExternalUpdate(obj, realime, act);
        if (this.motionPeformer === undefined) {
            this.motionPeformer = new Motion6DPerformer_1.Motion6DPerformer();
        }
        var a = this.motionPeformer.createUpdateFramesAction(this);
        act.addAction(a);
    }
}
exports.DataRuntimeConsumerMotion6DEvent = DataRuntimeConsumerMotion6DEvent;
