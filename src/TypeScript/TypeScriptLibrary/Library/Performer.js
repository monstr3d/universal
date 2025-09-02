"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Performer = void 0;
const AliasName_1 = require("./AliasName");
const OwnError_1 = require("./ErrorHandler/OwnError");
const FictiveAlias_1 = require("./Fiction/FictiveAlias");
const FictiveMeasurement_1 = require("./Fiction/FictiveMeasurement");
const FictiveMeasurements_1 = require("./Fiction/FictiveMeasurements");
class Performer {
    constructor() {
        this.a = 0;
        this.b = false;
        this.s = "";
    }
    convertTS(s, type) {
        if (this.implementsType(s, type)) {
            throw new OwnError_1.OwnError("Illegal type", "Illegal type: " + type, undefined);
        }
        return s;
    }
    updateChildrenData(dataConsumer) {
        var children = dataConsumer.getAllMeasurements();
        for (var child of children) {
            var o = child;
            if (this.implementsType(o, "IDataConsumer")) {
                var dc = child;
                this.updateChildrenData(dc);
            }
            child.updateMeasurements();
        }
    }
    convertArray(objects, type) {
        let s = [];
        for (var i = 0; i < objects.length; i++) {
            let o = objects[i];
            if (o.imlplementsType(type)) {
                s.push(o);
            }
        }
        return s;
    }
    convertMap(objects, type) {
        let map = new Map();
        var ent = objects.entries();
        for (const [key, val] of ent) {
            let o = val;
            if (o.imlplementsType(type)) {
                map.set(key, o);
            }
        }
        return map;
    }
    convertObject(s, type) {
        let ob = s;
        var t = [];
        if (ob.imlplementsType(type)) {
            var x = s;
            t.push(x);
        }
        return t;
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
    getDerivation(derivation) {
        let m = derivation.getDerivation();
        let x = m.getMeasurementValue();
        return this.convertFromAny(x);
    }
    getDerivationMeasurement(measurement) {
        let d = measurement;
        return this.getDerivation(d);
    }
    setDerivationValue(derivation, value) {
        let m = derivation.getDerivation();
        let iv = m;
        iv.setIValue(value);
    }
    setDerivationMeasuremtValue(measurement, value) {
        let d = measurement;
        this.setDerivationValue(d, value);
    }
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
        if (typeof t === "number") { // } && (t as unknown as S) instanceof Number) {  //VERY LIMITED AND UNSAFE EXAMPLE.
            return t; // Force the type assertion (VERY UNSAFE)
        }
        if (typeof t === "boolean") { //VERY LIMITED AND UNSAFE EXAMPLE.
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
        var keys = map.keys();
        /*    keys.foreach(
                key => alias.setAliasValue(key, map.get(key));
            );
            return;*/
        for (var key of keys) {
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
    getMeasurementsMap(measurements) {
        let map = new Map();
        var n = measurements.getMeasurementsCount();
        for (let i = 0; i < n; i++) {
            let m = measurements.getMeasurement(i);
            var nn = m.getMeasurementName();
            map.set(nn, m);
        }
        return map;
    }
    getMeasurementDC(consumer, name) {
        var mm = consumer.getAllMeasurements();
        for (var mea of mm) {
            var co = mea;
            var nm = co.getCategoryObjectName();
            nm += ".";
            var n = mea.getMeasurementsCount();
            for (let i = 0; i < n; i++) {
                var m = mea.getMeasurement(i);
                var nam = nm + m.getMeasurementName();
                if (nam == name) {
                    return m;
                }
            }
        }
        return new FictiveMeasurement_1.FictiveMeasurement();
    }
    getMeasurementsDCMap(consumer) {
        var map = new Map();
        var mm = consumer.getAllMeasurements();
        for (var mea of mm) {
            var co = mea;
            var nm = co.getCategoryObjectName();
            nm += ".";
            var n = mea.getMeasurementsCount();
            for (let i = 0; i < n; i++) {
                var m = mea.getMeasurement(i);
                var name = nm + m.getMeasurementName();
                map.set(name, m);
            }
        }
        return map;
    }
    getMeasurements(desktop, name) {
        var a = desktop.getCategoryObject(name);
        if (this.implementsType(a, "IMeasurements")) {
            var al = a;
            return al;
        }
        return new FictiveMeasurements_1.FictiveMeasurements();
    }
    getAlias(desktop, name) {
        var a = desktop.getCategoryObject(name);
        if (this.implementsType(a, "IAlias")) {
            var al = a;
            return al;
        }
        return new FictiveAlias_1.FictiveAlias();
    }
    getAliasName(desktop, name) {
        var l = name.length;
        var n = name.lastIndexOf('.');
        var s = name.substring(n + 1, l);
        var t = name.substring(0, n);
        var al = this.getAlias(desktop, t);
        return new AliasName_1.AliasName(al, s);
    }
}
exports.Performer = Performer;
//# sourceMappingURL=Performer.js.map