import type { IFactory } from "./IFactory";

export interface IFactoryConsumer {
    setConsumerFactory(factory: IFactory): void
    getConsumerFactory(): IFactory

}