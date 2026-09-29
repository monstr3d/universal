import type { IEvent } from "./IEvent";

export interface IEventHandler
{
    addEventToHandler(event: IEvent): void
    getEventHandlerEvents(): IEvent[]
}