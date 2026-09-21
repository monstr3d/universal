
import { DataRuntimeConsumerEvent } from "../../../Event/Runtime/DataRuntimeConsumerEvent";
import { Motion6DPerformer } from "../../Motion6DPerformer";
import type { IActionAddRemove } from "../../../Interfaces/IActionAddRemove";
import type { ICategoryObject } from "../../../Interfaces/ICategoryObject";
import type { IFactory } from "../../../Interfaces/IFactory";
import type { IObject } from "../../../Interfaces/IObject";
import type { IRealtimeCollection } from "../../../Interfaces/IRealtimeCollection";
import type { IDataConsumer } from "../../../Measurements/Interfaces/IDataConsumer";
import type { IReferenceFrame } from "../../Interfaces/IReferenceFrame";
import { IAddRemove } from "../../../Interfaces/IAddRemove";

export class DataRuntimeConsumerMotion6DEvent extends DataRuntimeConsumerEvent {

    protected motionPeformer: Motion6DPerformer = new Motion6DPerformer();
    constructor(dataConsumer: IDataConsumer, factory: IFactory) {
        super(dataConsumer, factory);
        if (this.motionPeformer === undefined) {
            this.motionPeformer = new Motion6DPerformer()
        }
        
    }


    protected prepare(dataConsumer: IDataConsumer) {
        super.prepare(dataConsumer)
                if (this.motionPeformer === undefined) {
            this.motionPeformer = new Motion6DPerformer()
        }
        var a = dataConsumer as unknown as IAddRemove
        if (a != undefined) {
            let ar = a.getAddRemoveObjects()
            for (var co of ar) {

            var fr = this.performer.convertObject<IReferenceFrame, ICategoryObject>(co, "IReferenceFrame")
            if (fr.length > 0) {
                this.motionPeformer.addRecursive(fr[0], this.categoryObjects)

            }
  }
  }
  }
    getExternalUpdate(obj: IObject | undefined, realime: IRealtimeCollection, act: IActionAddRemove): void {
        super.getExternalUpdate(obj, realime, act)
        if (this.motionPeformer === undefined) {
            this.motionPeformer = new Motion6DPerformer()
        }
        var a = this.motionPeformer.createUpdateFramesAction(this);
        act.addAction(a);
    }

}