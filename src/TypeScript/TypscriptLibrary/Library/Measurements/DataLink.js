"use strict";
class DataLink {
    constructor(name) {
        this.name = "";
        this.source = new FictiveDataConsumer();
        this.target = new FictiveMeasurements();
        this.name = name;
    }
    getSource() {
        return this.source;
    }
    getTagret() {
        return this.target;
    }
    setSource(source) {
        this.source = source;
    }
    setTarget(target) {
        this.target = target;
        this.source.add(this.target);
    }
    GetName() {
        return this.name;
    }
    ;
}
//# sourceMappingURL=DataLink.js.map