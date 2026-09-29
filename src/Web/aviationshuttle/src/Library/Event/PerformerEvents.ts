import type { IActionT } from "../Interfaces/IActionT";
import type { IComponentCollection } from "../Interfaces/IComponentCollection";
import type { IEventStart } from "../Interfaces/IEventStart";
import type { ITimerConsumer } from "../Interfaces/ITimerConsumer";
import type { ITimerFactory } from "../Interfaces/ITimerFactory";
import { Performer } from "../Performer";

export class PerformerEvents implements IActionT<IEventStart> {
    actionT(t: IEventStart): void
    {
        t.setEventEnabled(this.isEnabled)
    }

    isEnabled: boolean = false;

    static timeScale: number = 1;

    performer: Performer = new Performer()

    timerAction: TimerAction = new TimerAction()

    public static getTimeScale(): number {
        return this.timeScale
    }

    public static setTimeScale(timeScale: number): void {
        this.timeScale = timeScale;
    }

    public setComponentCollectionEnabled(collection: IComponentCollection, enabled: boolean): void {
        if (this.isEnabled == enabled) return
        this.isEnabled = enabled
        this.performer.forEach<IEventStart>(collection, this, "IEventStart")
    }

    public setComponentCollectionTimer(collection: IComponentCollection, factory: ITimerFactory) {
        if (factory === undefined) return
        this.timerAction.set(factory)
        this.performer.forEach<ITimerConsumer>(collection, this.timerAction, "ITimerConsumer")
    }

    isEmptyActionT(): boolean { return false }

}

class TimerAction implements IActionT<ITimerConsumer> {
    actionT(t: ITimerConsumer): void {
        t.setTimer(this.factory)
    }
    isEmptyActionT(): boolean { return false }

    set(factory: ITimerFactory) {
        this.factory = factory;
    }

    factory !: ITimerFactory;
}