"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.OrbitalForecastCalculation = void 0;
const RungeProcessor_1 = require("../../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor");
const PerformerMeasuremets_1 = require("../../../Library/Measurements/PerformerMeasuremets");
const Performer_1 = require("../../../Library/Performer");
const DataRuntimeConsumerODE_1 = require("../../../Library/Runtime/DataRuntimeConsumerODE");
const OrbitalForecast_1 = require("./OrbitalForecast");
const StopWatch_1 = require("../../../Library/Utilities/DateTime/StopWatch");
const Motion6DFactory_1 = require("../../../Library/Motion6D/Motion6DFactory");
class Check {
    check(o) {
        var s = `${o}`;
        var b = s.includes("NaN");
        if (b) {
            var i = 0;
        }
        return b;
    }
}
class Action {
    constructor(dc, p) {
        this.dc = dc;
        this.p = p;
    }
    action() {
        this.p.print(this.dc);
    }
    isEmptyAction() {
        return false;
    }
    dc;
    p;
}
class OrbitalForecastCalculation extends OrbitalForecast_1.OrbitalForecast {
    condition;
    act;
    constructor() {
        super();
        this.dc = this.getCategoryObject("Chart");
        this.alias = this.getCategoryObject("Motion equations");
        this.measurements = this.alias;
        this.performer.getMeasurementsMMap(this.measurements, this.map);
        let check = new Check();
        this.setCheck(check);
        this.performer.setCheker(this, check);
        this.act = new Action(this.dc, this.performer);
    }
    isEmptyAction() {
        return false;
    }
    func() {
        return this.contoller.signal.aborted;
    }
    action() {
        // eslint-disable-next-line no-var
        let rt = this.runtime.getTimeProvider();
        let t = rt.getTime();
        this.stopWatch.stop();
        const item = {
            orbitalTime: t,
            x: this.get("x"),
            y: this.get("y"),
            z: this.get("z"),
            vx: this.get("u"),
            vy: this.get("v"),
            vz: this.get("w"),
            duration: this.stopWatch.getTotalTime()
        };
        this.stopWatch.start();
        this.list.push(item);
    }
    getResult() {
        return this.list;
    }
    set(condition) {
        this.condition = condition;
        this.alias.setAliasValue("x", condition.x);
        this.alias.setAliasValue("y", condition.y);
        this.alias.setAliasValue("z", condition.z);
        this.alias.setAliasValue("u", condition.vx);
        this.alias.setAliasValue("v", condition.vy);
        this.alias.setAliasValue("w", condition.vz);
        this.list = [];
        let processor = new RungeProcessor_1.RungeProcessor();
        this.runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, new Motion6DFactory_1.Motion6DFactory());
    }
    calculate = async (condition, controller) => {
        this.contoller = controller;
        this.set(condition);
        let p = new PerformerMeasuremets_1.PerformerMeasuremets();
        this.stopWatch = new StopWatch_1.StopWatch();
        this.stopWatch.start();
        var count = Math.floor(condition.end - condition.begin);
        p.peformCondDCFixedStepCalculation(this.runtime, this.dc, "Recursive.y", this, condition.begin, 1, count, this);
        this.stopWatch.stop();
        return this.list;
    };
    performFixedStepCalculation() {
        this.stopWatch = new StopWatch_1.StopWatch();
        this.stopWatch.start();
        let p = new PerformerMeasuremets_1.PerformerMeasuremets();
        p.performFixedStepCalculation(this.runtime, this.condition.begin, 1, this.condition.end, this, this.act);
    }
    get(i) {
        let variable = this.map.get(i);
        return this.performer.convertFromAny(variable?.getMeasurementValue());
    }
    list = [];
    contoller = new AbortController();
    alias;
    measurements;
    dc;
    runtime;
    performer = new Performer_1.Performer();
    map = new Map();
    stopWatch;
}
exports.OrbitalForecastCalculation = OrbitalForecastCalculation;
;
