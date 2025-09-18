"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.OrbitalForecastCalculation = void 0;
const RungeProcessor_1 = require("../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor");
const PefrormerMeasuremets_1 = require("../../Library/Measurements/PefrormerMeasuremets");
const Performer_1 = require("../../Library/Performer");
const DataRuntimeConsumerODE_1 = require("../../Library/Runtime/DataRuntimeConsumerODE");
const OrbitalForecast_1 = require("./OrbitalForecast");
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
}
class OrbitalForecastCalculation extends OrbitalForecast_1.OrbitalForecast {
    constructor() {
        super();
        this.calculate = (condition, controller) => __awaiter(this, void 0, void 0, function* () {
            this.contoller = controller;
            this.set(condition);
            let p = new PefrormerMeasuremets_1.PefrormerMeasuremets();
            p.peformCondDCFixedStepCalculation(this.runtime, this.dc, "Recursive.y", this, condition.Begin, 1, condition.End, this);
            return this.list;
        });
        this.list = [];
        this.contoller = new AbortController();
        this.performer = new Performer_1.Performer();
        this.map = new Map();
        this.dc = this.getCategoryObject("Chart");
        this.alias = this.getCategoryObject("Motion equations");
        this.measurements = this.alias;
        this.performer.getMeasurementsMMap(this.measurements, this.map);
        let check = new Check();
        this.setCheck(check);
        this.performer.setCheker(this, check);
        this.act = new Action(this.dc, this.performer);
    }
    func() {
        return this.contoller.signal.aborted;
    }
    action() {
        // eslint-disable-next-line no-var
        let rt = this.runtime.getTimeProvider();
        let t = rt.getTime();
        const item = {
            OrbitalTime: t,
            X: this.get("x"),
            Y: this.get("y"),
            Z: this.get("z"),
            Vx: this.get("u"),
            Vy: this.get("v"),
            Vz: this.get("w")
        };
        this.list.push(item);
    }
    getResult() {
        return this.list;
    }
    set(condition) {
        this.condition = condition;
        this.alias.setAliasValue("x", condition.X);
        this.alias.setAliasValue("y", condition.Y);
        this.alias.setAliasValue("z", condition.Z);
        this.alias.setAliasValue("v", condition.Vx);
        this.alias.setAliasValue("u", condition.Vy);
        this.alias.setAliasValue("w", condition.Vz);
        this.list = [];
        let processor = new RungeProcessor_1.RungeProcessor();
        this.runtime = new DataRuntimeConsumerODE_1.DataRuntimeConsumerODE(this.dc, processor);
    }
    performFixedStepCalculation() {
        let p = new PefrormerMeasuremets_1.PefrormerMeasuremets();
        p.performFixedStepCalculation(this.runtime, this.condition.Begin, 1, this.condition.End, this, this.act);
    }
    get(i) {
        let variable = this.map.get(i);
        return this.performer.convertFromAny(variable === null || variable === void 0 ? void 0 : variable.getMeasurementValue());
    }
}
exports.OrbitalForecastCalculation = OrbitalForecastCalculation;
;
//# sourceMappingURL=OrbitalForecastCalculation.js.map