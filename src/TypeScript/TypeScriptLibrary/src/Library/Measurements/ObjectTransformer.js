"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ObjectTransformer = void 0;
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
const CategoryObject_1 = require("../CategoryObject");
const OwnError_1 = require("../ErrorHandler/OwnError");
const Performer_1 = require("../Performer");
class ObjectTransformer extends CategoryObject_1.CategoryObject {
    // ----------------------------------------
    // Region: Data Types and Variables
    // ----------------------------------------
    // Fields
    /// <summary>
    /// This object as IObjectTransformer
    /// </summary>
    transformer;
    performer = new Performer_1.Performer();
    /// <summary>
    /// Input
    /// </summary>
    input = [];
    /// <summary>
    /// Output measurements
    /// </summary>
    outMea = [];
    /// <summary>
    /// Input measurements
    /// </summary>
    inMea = [];
    /// <summary>
    /// Input objects
    /// </summary>
    inO = [];
    /// <summary>
    /// Output objects
    /// </summary>
    outO = [];
    /// <summary>
    /// Single output
    /// </summary>
    outS = [];
    /// <summary>
    /// Single input
    /// </summary>
    inS = [];
    /// <summary>
    /// The "is updated" sign
    /// </summary>
    isUpdated = false;
    /// <summary>
    /// External measurements
    /// </summary>
    /// <summary>
    /// Providers of measurements
    /// </summary>
    measurements = [];
    /// <summary>
    /// Links to variables
    /// </summary>
    links = new Map();
    /// <summary>
    /// Providers of measurements
    /// </summary>
    providers = [];
    cons;
    transformers = [];
    constructor(desktop, name) {
        super(desktop, name);
        this.typeName = "ObjectTransformer";
        this.types.push("ObjectTransformer");
        this.types.push("IObjectTransformerConsumer");
        this.types.push("IDataConsumer");
        this.types.push("IMeasurements");
        this.types.push("IPostSetArrow");
        this.cons = this;
    }
    resetDataConsumer() {
    }
    postSetArrow() {
        this.initTransformer();
    }
    getMeasurementsCount() {
        return this.outMea.length;
    }
    getMeasurement(i) {
        return this.outMea[i];
    }
    updateMeasurements() {
        //this.performer.updateChildrenData(this);
        for (var i = 0; i < this.inO.length; i++) {
            var m = this.inMea[i];
            this.inO[i] = m.getMeasurementValue();
        }
        this.transformer.calculate(this.inO, this.outO);
    }
    addMeasurement(measurement) {
        this.outMea.push(measurement);
    }
    getAllMeasurements() {
        return this.measurements;
    }
    addMeasurements(item) {
        this.measurements.push(item);
    }
    addTransformer(transformer) {
        if (this.transformer != null) {
            throw new OwnError_1.OwnError("", "", "");
        }
        this.transformer = transformer;
    }
    initTransformer() {
        var inp = this.transformer.getInput();
        var out = this.transformer.getOutput();
        this.inO = new Array(inp.length);
        this.outO = new Array(out.length);
        this.createOutput();
    }
    createOutput() {
        this.inMea = [];
        var outS = this.transformer.getOutput();
        for (var i = 0; i < outS.length; i++) {
            var name = outS[i];
            var type = this.getOutputType(i);
            this.outMea.push(new TransMeasurement(i, this.outO, name, type));
        }
        var mm = this.performer.getMeasurementsDCMap(this);
        var ent = this.links.entries();
        for (var [s, t] of ent) {
            this.s = s;
            var mt = mm.get(t);
            if (mt != undefined) {
                this.inMea.push(mt);
            }
        }
    }
    s = "";
    getOutputType(i) {
        return this.transformer.getOutputType(i);
    }
    setLinks(map) {
        this.performer.copyMap(map, this.links);
    }
}
exports.ObjectTransformer = ObjectTransformer;
class TransMeasurement {
    n;
    outO = [];
    name = "";
    type;
    links = new Map();
    performer = new Performer_1.Performer();
    setLinks(links) {
        this.performer.copyMap(links, this.links);
    }
    constructor(n, outO, name, type) {
        this.n = n;
        this.outO = outO;
        this.name = name;
        this.type = type;
    }
    getMeasurementName() {
        return this.name;
    }
    getMeasurementType() {
        return this.type;
    }
    getMeasurementValue() {
        return this.outO[this.n];
    }
}
