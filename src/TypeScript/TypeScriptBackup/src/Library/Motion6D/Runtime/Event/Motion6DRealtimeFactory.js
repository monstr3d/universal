"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Motion6DRealtimeFactory = void 0;
const DataRuntimeConsumerMotion6DEvent_1 = require("./DataRuntimeConsumerMotion6DEvent");
const EmptyRealtimeCollection_1 = require("../../../Runtime/EmptyRealtimeCollection");
const FactoryObject_1 = require("../../../FactoryObject");
class Motion6DRealtimeFactory extends FactoryObject_1.FactoryObject {
    constructor(mF) {
        super("", mF);
        this.mF = mF;
        this.types.push("IRealtimeCollectionFactory");
        this.types.push("Motion6DRealtimeFactory");
        this.typeName = "Motion6DRealtimeFactory";
    }
    createRealtimeFromCollection(collection) {
        this.collection = collection;
        return new EmptyRealtimeCollection_1.EmptyRealtimeCollection();
    }
    createRealtimeFromDataConsumer(consumer) {
        return new DataRuntimeConsumerMotion6DEvent_1.DataRuntimeConsumerMotion6DEvent(consumer, this.mF);
    }
}
exports.Motion6DRealtimeFactory = Motion6DRealtimeFactory;
//# sourceMappingURL=Motion6DRealtimeFactory.js.map