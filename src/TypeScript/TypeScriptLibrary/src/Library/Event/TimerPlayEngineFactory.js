"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TimerPlayEngineFactory = void 0;
const TimeSpan_1 = require("../Utilities/DateTime/TimeSpan");
const ActionArray_1 = require("../Utilities/Generic/ActionArray");
const EmptyActionT_1 = require("./Objects/EmptyActionT");
class TimerPlayEngineFactory {
    constructor(engine) {
        this.engine = engine;
        engine.getEngineAction().addActionT(this);
    }
    actionT(t) {
        for (let timer of this.timers) {
            timer.setTime(t);
        }
    }
    isEmptyActionT() { return false; }
    isTimerFactoryEnabled() {
        return this.enabled;
    }
    setTimerFactoryEnabled(enabled) {
        this.enabled = enabled;
    }
    enabled = false;
    getTimerFromFactory(timeSpan) {
        var t = new Timer(this, timeSpan);
        this.timers.push(t);
        return t;
    }
    timers = [];
    engine;
}
exports.TimerPlayEngineFactory = TimerPlayEngineFactory;
class Timer {
    actionT = new EmptyActionT_1.EmptyActionT();
    constructor(factory, span) {
        this.span = span;
        this.factory = factory;
        this.interval = span.getTotalMilliseconds() / 1000;
    }
    setTimerEventT(action) {
        this.actionT = action;
    }
    getTimerTimeSpan() {
        return this.span;
    }
    isTimerEnabled() {
        return this.factory.isTimerFactoryEnabled();
    }
    setTimerEnabled(enabled) {
        var b = this.factory.isTimerFactoryEnabled();
        if (b != enabled)
            this.factory.setTimerFactoryEnabled(enabled);
    }
    getTimerEvent() {
        return this.action;
    }
    setTime(time) {
        if (this.last == this.lt) {
            this.last = time;
            return;
        }
        if (time > this.last + this.interval) {
            this.action.action();
            this.actionT.actionT(time);
            this.last = time;
        }
    }
    factory;
    span = new TimeSpan_1.TimeSpan(1000000);
    last = Math.min();
    lt = Math.min();
    action = new ActionArray_1.ActionArray();
    interval = 0;
}
