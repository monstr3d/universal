import type { IDesktop } from "../../Interfaces/IDesktop";
import type { IScadaInterface } from "./IScadaInterface";

export interface IScadaFactory {
    createScada(desktop: IDesktop, dataConsumer: string): IScadaInterface
}