import type { IExceptionHandler } from "../../Interfaces/IExceptionHandler";
import type { IActionAddRemove } from "../../Interfaces/IActionAddRemove";
import type { IActionAddRemoveT } from "../../Interfaces/IActionAddRemoveT";
import type { IFunc } from "../../Interfaces/IFunc";
import type { INamed } from "../../NamedTree/Interfaces/INamed";
import type { IScadaEvent } from "./IScadaEvent";
import type { IObjectCollection } from "../../Interfaces/IObjectCollection";
import type { IInput } from "../../Interfaces/IInput";
import type { IActionT } from "../../Interfaces/IActionT";

export interface IScadaInterface extends INamed, IObjectCollection, IActionT<number> {

    getScadaInputs(): IInput[]

    getScadaOutputs(): Map<string, any>

    setScadaConstant(name: string, value: any): void

    getScadaConstant(name: string): any

    getScadaConstants(): Map<string, any>

    getScadaEventsArray(): string[]

    getScadaObects(): Map<string, string[]>

    getScadaInputEvent(name: string): IActionAddRemoveT<any> | undefined


    getScadaConstantEvent(name: string): IActionAddRemoveT<any> | undefined


    getScadaOutputFunc(name: string): IFunc<any> | undefined

    getScadaEvent(name: string): IScadaEvent | undefined

    getScadaObject<T>(name: string, type: string): T[]

    setScadaEnabled(enabled: boolean) : void

    isScadaEnabled(): boolean

    getScadaStop(): IActionAddRemove

    getScadaStart(): IActionAddRemove

    getScadaExceptionHanler(): IExceptionHandler

    setScadaExceptionHanler(e: IExceptionHandler): void

    refreshScada(): void

    getScadaRefresh(): IActionAddRemove


}

