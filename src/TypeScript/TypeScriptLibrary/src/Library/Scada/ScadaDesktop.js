"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ScadaDesktop = void 0;
const ScadaInterface_1 = require("./ScadaInterface");
class ScadaDesktop extends ScadaInterface_1.ScadaInterface {
    constructor(componentCollection) {
        super();
        this.types.push("ScadaDesktop");
        this.types.push("IComponentCollectionHolder");
        this.typeName = "ScadaDesktop";
        this.componentCollection = componentCollection;
        let oc = componentCollection;
        this.performer.getInputsFromCollection(oc, this.inputs);
    }
    getComponentCollection() {
        return this.componentCollection;
    }
    setComponentCollection(collection) {
        this.componentCollection = collection;
    }
    getObjectCollection() {
        return this.componentCollection.getObjectCollection();
    }
    getScadaObject(name, type) {
        return this.performer.getCollectionObject(this.componentCollection, name, type);
    }
    componentCollection;
    runtime;
    setScadaEnabled(enabled) {
        super.setScadaEnabled(enabled);
        this.runtime.setComponentCollectionRunning(enabled);
    }
    isScadaEnabled() {
        return this.runtime.isComponentCollectionRunning();
    }
    createRuntime() {
    }
    getStepAction() {
        let l = this.performer.convertObject(this.runtime, "IStepActionHolder");
        return l.length == 0 ? undefined : l[0].getStepAction();
    }
}
exports.ScadaDesktop = ScadaDesktop;
