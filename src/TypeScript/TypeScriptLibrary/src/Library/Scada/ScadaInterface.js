"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ScadaInterface = void 0;
const ActionArray_1 = require("../Utilities/Generic/ActionArray");
const Performer_1 = require("../Performer");
class ScadaInterface {
    constructor() {
    }
    actionT(time) {
        if (time < this.currentTime) {
            this.currentTime = time;
            return;
        }
        if (this.stepAction != undefined) {
            this.stepAction.actionT2(this.currentTime, time);
        }
        this.currentTime = time;
    }
    isEmptyActionT() {
        return false;
    }
    getClassName() {
        return this.typeName;
    }
    imlplementsType(type) {
        return this.types.includes(type);
    }
    getName() {
        return this.name;
    }
    name = "";
    typeName = "ScadaInterface";
    types = ["IObject", "IScadaInterface", "IObjectCollection", "ScadaInterface",
        "IStepActionHolder"];
    performer = new Performer_1.Performer();
    inputs = [];
    outputs = new Map();
    constants = new Map();
    objects = new Map();
    events = [];
    //  !!! FOR LATER EVENTS WITH ARGUMENTS   protected List<string> eventOutputs = new List<string>();
    dInput = new Map();
    dConstant = new Map();
    fConstant = new Map();
    dEvents = new Map();
    dEventOutputs = new Map();
    dOutput = new Map();
    /// <summary>
    /// On start event
    /// </summary>
    onStart = new ActionArray_1.ActionArray();
    /// <summary>
    /// On Stop event
    /// </summary>
    onStop = new ActionArray_1.ActionArray();
    onRefresh = new ActionArray_1.ActionArray();
    isEnabled = false;
    exceptionHandler;
    stepAction;
    currentTime = Number.MAX_VALUE;
    any;
    getScadaInputs() {
        return this.inputs;
    }
    getScadaOutputs() {
        return this.outputs;
    }
    setScadaConstant(name, value) {
        this.constants.set(name, value);
    }
    getScadaConstant(name) {
        return this.constants.get(name);
    }
    getScadaConstants() {
        return this.constants;
    }
    getScadaEventsArray() {
        return this.events;
    }
    getScadaObects() {
        return this.objects;
    }
    getScadaInputEvent(name) {
        return this.dInput.get(name);
    }
    getScadaConstantEvent(name) {
        return this.dConstant.get(name);
    }
    getScadaOutputsFunc(name) {
        this.any = name;
        return undefined;
    }
    getScadaOutputFunc(name) {
        return this.dOutput.get(name);
    }
    getScadaEvent(name) {
        return this.dEvents.get(name);
    }
    setScadaEnabled(enabled) {
        this.isEnabled = enabled;
        this.currentTime = Number.MAX_VALUE;
        let sa = this.getStepAction();
        if (sa != undefined)
            this.stepAction = sa;
    }
    isScadaEnabled() {
        return this.isEnabled;
    }
    getScadaStop() {
        return this.onStop;
    }
    getScadaStart() {
        return this.onStart;
    }
    getScadaExceptionHanler() {
        return this.exceptionHandler;
    }
    setScadaExceptionHanler(e) {
        this.exceptionHandler = e;
    }
    refreshScada() {
    }
    getScadaRefresh() {
        return this.onRefresh;
    }
    getNamedName() {
        return this.name;
    }
    setNamedName(name) {
        this.name = name;
    }
}
exports.ScadaInterface = ScadaInterface;
