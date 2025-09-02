"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ArrayMeasurement = void 0;
class ArrayMeasurement {
    constructor(arrElement, n, name, type) {
        this.array = [];
        this.name = "";
        this.n = 0;
        this.types = ["ArrayMeasurement", "IMeasurement", "IObject"];
        this.className = "ArrayMeasurement";
        this.n = n;
        this.name = name;
        this.type = type;
    }
    getClassName() {
        return this.className;
    }
    imlplementsType(type) {
        return this.types.indexOf(type) >= 0;
    }
    getName() {
        return this.name;
    }
    getMeasurementName() {
        return this.name;
    }
    getMeasurementType() {
        return this.type;
    }
    getMeasurementValue() {
        return this.array[this.n];
    }
}
exports.ArrayMeasurement = ArrayMeasurement;
//# sourceMappingURL=ArrayMeasurement.js.map