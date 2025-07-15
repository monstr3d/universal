"use strict";
class DataConsumer {
    constructor() {
        this.measurements = [];
    }
    get() {
        return this.measurements;
    }
    add(item) {
        this.measurements.push(item);
    }
}
//# sourceMappingURL=DataConsumer.js.map