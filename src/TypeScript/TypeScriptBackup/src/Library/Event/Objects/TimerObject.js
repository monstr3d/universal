"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TimerObject = void 0;
const CategoryObject_1 = require("../../CategoryObject");
const ActionArray_1 = require("../../Utilities/Generic/ActionArray");
const TimeSpan_1 = require("../../Utilities/DateTime/TimeSpan");
const ActionArrayT_1 = require("../../Utilities/Generic/ActionArrayT");
class TimerObject extends CategoryObject_1.CategoryObject {
    constructor(desktop, name) {
        super(desktop, name);
        this.action = new ActionArray_1.ActionArray();
        this.actionT = new ActionArrayT_1.ActionArrayT();
        this.span = new TimeSpan_1.TimeSpan(1.0);
        this.isEnabled = false;
        this.typeName = "TimerObject";
        this.types.push("IEvent");
        this.types.push("ITimerConsumer");
        this.types.push("IPostSetArrow");
        this.types.push("TimerObject");
    }
    postSetArrow() {
    }
    getTimeSpan() {
        return this.span;
    }
    setTimer(timerFactory) {
        this.timer = timerFactory.getTimerFromFactory(this.span);
        this.timer.getTimerEvent().addAction(this.action);
        this.timer.setTimerEventT(this.eventActionT());
    }
    eventAction() {
        return this.action;
    }
    eventActionT() {
        return this.actionT;
    }
    isEventEnabled() {
        return this.isEnabled;
    }
    setEventEnabled(enabled) {
        if (this.isEnabled == enabled)
            return;
        this.isEnabled = enabled;
        this.timer.setTimerEnabled(enabled);
    }
}
exports.TimerObject = TimerObject;
//# sourceMappingURL=TimerObject.js.map