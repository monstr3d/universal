"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Performer = void 0;
const OwnError_1 = require("./ErrorHandler/OwnError");
class Performer {
    constructor() {
        this.a = 0;
        this.b = false;
        this.s = "";
    }
    select(objects, type) {
        let t = [];
        for (var i = 0; i < objects.length; i++) {
            let o = objects[i];
            if (o.imlplementsType(type)) {
                t.push(o);
            }
        }
        return t;
    }
    convertOperationToNumber(operation) {
        return () => {
            let value = operation();
            if (typeof value === 'number') {
                return value; // Already a number
            }
            return 0;
        };
    }
    /*
     public getAnyTimeOperation(consumer: ITimeMeasurementConsumer): Operation<any> {
        var m = consumer.getTimeMeasutement();
        return () => { m.getOperation()(); }
    }

    public getNumberTimeOperation(consumer: ITimeMeasurementConsumer): Operation<number> {
        return () => {
            var m = consumer.getTimeMeasutement();
            var v = m.getOperation();
            var value = v();
            if (typeof value === 'number') {
                return value;
            }
            return 0;
        }
    }*/
    convertFromAny(t) {
        return this.convert(t);
    }
    convert(t) {
        // Typeof checks against string representations of types. S is a generic type,
        // so you can't directly use typeof S.  It will just return the string "object" or "function".
        // You need to find a way to determine the *actual* type S at runtime
        //  and compare it against the type of 't'.
        // A very limited approach would be to use type guards, but that means
        // you'd have to know what type S *could* be in advance. This is not
        // really a general solution.
        if (typeof t === "string" && null instanceof String) { //VERY LIMITED AND UNSAFE EXAMPLE.
            return t; // Force the type assertion (VERY UNSAFE)
        }
        if (typeof t === "number" && null instanceof Number) { //VERY LIMITED AND UNSAFE EXAMPLE.
            return t; // Force the type assertion (VERY UNSAFE)
        }
        if (typeof t === "boolean" && null instanceof Boolean) { //VERY LIMITED AND UNSAFE EXAMPLE.
            return t; // Force the type assertion (VERY UNSAFE)
        }
        //This is better, but assumes S is a string or number
        if (typeof t === 'string' && null === String) {
            return t;
        }
        if (typeof t === 'number' && null === Number) {
            return t;
        }
        throw new OwnError_1.OwnError("Type conversion", "Performer", undefined);
        // In many cases, a direct conversion may not be possible
        // or may require a more complex transformation.
        // console.warn("Conversion not possible for types:", typeof t, S);
        return undefined; // Or throw an error, or return a default value.
    }
    getMeasurement(i, j, dataConsumer) {
        return dataConsumer.getAllMeasurements()[i].getMeasurement(j);
    }
    enlarge(t, x, size) {
        for (let i = 0; i < size; i++)
            t.push(x);
    }
    enlarge2(t, x, row, column) {
        for (let i = 0; i < row; i++) {
            let y = [];
            t.push(y);
            for (let j = 0; i < column; j++)
                y.push(x);
        }
    }
    enlargeNumber(x, size) {
        this.enlarge(x, 0, size);
    }
    enlargeNumber2(x, row, column) {
        this.enlarge2(x, 0, row, column);
    }
    copyArray(f, t) {
        let i = 0;
        for (i = 0; i < f.length; i++) {
            t.push(f[i]);
        }
    }
    setAliasType(name, value, map, names) {
        if (map.has(name)) {
            return false;
        }
        names.push(name);
        if (typeof value === 'number') {
            map.set(name, this.a);
        }
        if (typeof value === 'boolean') {
            map.set(name, this.b);
        }
        if (typeof value === 'string') {
            map.set(name, this.s);
        }
        return true;
    }
    setAliasMap(map, alias) {
        for (const key in map.keys()) {
            alias.setAliasValue(key, map.get(key));
        }
    }
    copyMap(s, t) {
        for (const [key, value] of s) {
            t.set(key, value);
        }
    }
    implementsType(o, type) {
        let obj = o;
        return obj.imlplementsType(type);
    }
}
exports.Performer = Performer;
//# sourceMappingURL=Performer.js.map