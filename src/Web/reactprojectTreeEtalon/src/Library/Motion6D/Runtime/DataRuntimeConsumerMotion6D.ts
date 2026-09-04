import type { IFactory } from "../../Interfaces/IFactory"
import type { IDataConsumer } from "../../Measurements/Interfaces/IDataConsumer"
import { DataRuntimeConsumerODE } from "../../Runtime/DataRuntimeConsumerODE"

export class DataRuntimeConsumerMotion6D extends DataRuntimeConsumerODE {
    constructor(dataConsumer: IDataConsumer, factory: IFactory) {
        super(dataConsumer, factory)
    }

    protected prepare(dataConsumer: IDataConsumer): void {
        super.prepare(dataConsumer)
    }

}