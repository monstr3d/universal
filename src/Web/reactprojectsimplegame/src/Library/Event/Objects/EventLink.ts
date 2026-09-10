import { CategoryArrow } from "../../CategoryArrow";
import { OwnNotImplemented } from "../../ErrorHandler/OwnNotImplemented";
import type { ICategoryObject } from "../../Interfaces/ICategoryObject";
import type { IDesktop } from "../../Interfaces/IDesktop";
import type { IEvent } from "../../Interfaces/IEvent";
import type { IEventHandler } from "../../Interfaces/IEventHandler";

export class EventLink extends CategoryArrow
{
    constructor(desktop: IDesktop, name: string) {
        super(desktop, name)
    }

    setSource(source: ICategoryObject): void {
        var h = this.getObjectT<IEventHandler, ICategoryObject>(source, "IEventHandler")
        if (h.length == 0) {
            throw new OwnNotImplemented("EVENT LINK");
        }
        this.handler = h[0]
        super.setSource(source)
    }

    setTarget(target: ICategoryObject): void {
        this.target = target;
        var e = this.getObjectT<IEvent, ICategoryObject>(target, "IEvent")
        if (e.length == 0) {
            throw new OwnNotImplemented("Event link");
        }
        this.event = e[0]
        this.handler.addEventToHandler(e[0])
        super.setTarget(target)
 }

    event !: IEvent

    handler !: IEventHandler 
    /*

         public IEventHandler Source { get => source; }

        /// <summary>
        /// The event (target)
        /// </summary>
        public IEvent Target { get => target; }

    */

}