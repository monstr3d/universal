import type { IScadaInterface } from "./IScadaInterface";

export interface IScadaConsumer {
    getConsumerScada(): IScadaInterface
    setConsumerScada(scada: IScadaInterface): boolean
}