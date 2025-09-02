"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ObjectTransformer = void 0;
const CategoryObject_1 = require("../CategoryObject");
const OwnError_1 = require("../ErrorHandler/OwnError");
const FictiveDataConsumer_1 = require("../Fiction/FictiveDataConsumer");
const Performer_1 = require("../Performer");
class ObjectTransformer extends CategoryObject_1.CategoryObject {
    constructor(desktop, name) {
        super(desktop, name);
        this.performer = new Performer_1.Performer();
        /// <summary>
        /// Input
        /// </summary>
        this.input = [];
        /// <summary>
        /// Output measurements
        /// </summary>
        this.outMea = [];
        /// <summary>
        /// Input measurements
        /// </summary>
        this.inMea = [];
        /// <summary>
        /// Input objects
        /// </summary>
        this.inO = [];
        /// <summary>
        /// Output objects
        /// </summary>
        this.outO = [];
        /// <summary>
        /// Single output
        /// </summary>
        this.outS = [];
        /// <summary>
        /// Single input
        /// </summary>
        this.inS = [];
        /// <summary>
        /// The "is updated" sign
        /// </summary>
        this.isUpdated = false;
        /// <summary>
        /// External measurements
        /// </summary>
        /// <summary>
        /// Providers of measurements
        /// </summary>
        this.measurements = [];
        /// <summary>
        /// Links to variables
        /// </summary>
        this.links = new Map();
        /// <summary>
        /// Providers of measurements
        /// </summary>
        this.providers = [];
        this.cons = new FictiveDataConsumer_1.FictiveDataConsumer();
        this.transformers = [];
        this.typeName = "ObjectTransformer";
        this.types.push("ObjectTransformer");
        this.types.push("IObjectTransformerConsumer");
        this.types.push("IDataConsumer");
        this.types.push("IMeasurements");
        this.types.push("IPostSetArrow");
        this.cons = this;
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
        this.performer.updateChildrenData(this);
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
            var mt = mm.get(t);
            if (mt != undefined) {
                this.inMea.push(mt);
            }
        }
    }
    getOutputType(i) {
        return this.transformer.getOutputType(i);
    }
    setLinks(map) {
        this.performer.copyMap(map, this.links);
    }
}
exports.ObjectTransformer = ObjectTransformer;
class TransMeasurement {
    setLinks(links) {
        this.performer.copyMap(links, this.links);
    }
    constructor(n, outO, name, type) {
        this.outO = [];
        this.name = "";
        this.links = new Map();
        this.performer = new Performer_1.Performer();
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
//# sourceMappingURL=ObjectTransformer.js.map