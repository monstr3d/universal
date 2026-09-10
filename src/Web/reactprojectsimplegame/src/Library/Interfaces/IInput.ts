import type { IEvent } from "./IEvent";

export interface IInput extends IEvent {

    getInputTypes(): Map<string, any>

    getInitalConditions(): Map<string, any>

    setInputValue(name: string, value: any): void

}
