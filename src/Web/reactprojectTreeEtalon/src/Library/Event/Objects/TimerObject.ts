import { CategoryObject } from "../../CategoryObject";
import { ActionArray } from "../../Utilities/Generic/ActionArray";
import  { TimeSpan } from "../../Utilities/DateTime/TimeSpan";
import { ActionArrayT } from "../../Utilities/Generic/ActionArrayT";
import type { IActionAddRemove } from "../../Interfaces/IActionAddRemove";
import type { IDesktop } from "../../Interfaces/IDesktop";
import type { IEvent } from "../../Interfaces/IEvent";
import type { ITimer } from "../../Interfaces/ITimer";
import type { ITimerConsumer } from "../../Interfaces/ITimerConsumer";
import type { ITimerFactory } from "../../Interfaces/ITimerFactory";
import type { IPostSetArrow } from "../../Interfaces/IPostSetArrow";
import type { IActionAddRemoveT } from "../../Interfaces/IActionAddRemoveT";

export class TimerObject extends CategoryObject implements IEvent, ITimerConsumer, IPostSetArrow {

    constructor(desktop: IDesktop, name: string) {
        super(desktop, name)
        this.typeName = "TimerObject"
        this.types.push("IEvent")
        this.types.push("ITimerConsumer")
        this.types.push("IPostSetArrow")
        this.types.push("TimerObject")
    }
    postSetArrow(): void {
    }

    getTimeSpan(): TimeSpan {
        return this.span;
    }

    setTimer(timerFactory: ITimerFactory): void {
        this.timer = timerFactory.getTimerFromFactory(this.span)
        this.timer.getTimerEvent().addAction(this.action)
        this.timer.setTimerEventT(this.eventActionT())
 }


    eventAction(): IActionAddRemove {
        return this.action;
    }

    public eventActionT(): IActionAddRemoveT<number> {
        return this.actionT;
    }


    isEventEnabled(): boolean {
        return this.isEnabled;
    }

    setEventEnabled(enabled: boolean): void {
        if (this.isEnabled == enabled)
            return;
        this.isEnabled = enabled;
        this.timer.setTimerEnabled(enabled)
    }



    action: IActionAddRemove = new ActionArray();

    actionT: IActionAddRemoveT<number> = new ActionArrayT<number>();

    timer !: ITimer;

    protected span: TimeSpan = new TimeSpan(1.0);

    isEnabled: boolean = false;


}