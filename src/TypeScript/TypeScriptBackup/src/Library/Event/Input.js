"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Input = void 0;
const CategoryObject_1 = require("../CategoryObject");
const EmptyObject_1 = require("../EmptyObject");
const ActionArray_1 = require("../Utilities/Generic/ActionArray");
class Input extends CategoryObject_1.CategoryObject {
    constructor(desktop, name) {
        super(desktop, name);
        this.measuremenrs = [];
        this.inputtypes = new Map;
        this.inputconitions = new Map;
        this.num = new Map;
        this.data = [];
        this.idata = [];
        this.array = [];
        this.measurements = [];
        this.en = false;
        this.action = new ActionArray_1.ActionArray;
        this.fx = 0;
        this.types.push("IInput");
        this.types.push("IEvent");
        this.types.push("IMeasurements");
        this.types.push("Input");
        this.typeName = "Input";
    }
    startedStart(start) {
        this.fx = start;
        for (let i = 0; i < this.idata.length; i++)
            this.data[i] = this.idata[i];
    }
    getMeasurementsCount() {
        return this.measuremenrs.length;
    }
    getMeasurement(i) {
        return this.measuremenrs[i];
    }
    updateMeasurements() {
    }
    getInputTypes() {
        return this.inputtypes;
    }
    getInitalConditions() {
        return this.inputconitions;
    }
    setInputValue(name, value) {
        if (this.num.has(name)) {
            let n = this.num.get(name);
            if (n != undefined) {
                if (this.data[n] != value) {
                    this.data[n] = value;
                    this.action.action();
                }
            }
        }
    }
    eventAction() {
        return this.action;
    }
    isEventEnabled() {
        return true;
    }
    setEventEnabled(enabled) {
        this.en = enabled;
    }
    createAll() {
        let i = 0;
        for (let x of this.array) {
            let n = x[0];
            let type = x[0];
            let value = x[1];
            this.num.set(n, i);
            this.inputtypes.set(n, type);
            this.inputconitions.set(n, value);
            this.idata.push(value);
            this.data.push(value);
            const m = new Measurement(n, this.data, type, i);
            this.measuremenrs.push(m);
            ++i;
        }
    }
}
exports.Input = Input;
class Measurement extends EmptyObject_1.EmptyObject {
    constructor(name, data, type, num) {
        super(name);
        this.data = data;
        this.type = type;
        this.num = num;
    }
    getMeasurementName() {
        return this.name;
    }
    getMeasurementType() {
        return this.type;
    }
    getMeasurementValue() {
        return this.data[this.num];
    }
}
//# sourceMappingURL=Input.js.map