"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Converter3DPefrormer = void 0;
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
const Performer_1 = require("../Performer");
const ColorTexture_1 = require("./ColorTexture");
const PointTexture_1 = require("./Points/PointTexture");
class Converter3DPefrormer {
    constructor() {
        this.performer = new Performer_1.Performer();
    }
    toReal(s) {
        return this.performer.toNumber(s);
    }
    toRealArray(str) {
        let ss = str.split(" ");
        var x = [];
        for (let s of ss) {
            if (s.length > 0) {
                let a = this.toReal(s);
                x.push(a);
            }
        }
        return x;
    }
    createPointTexture(geometry, vertex, texture, normal) {
        return new PointTexture_1.PointTexture(geometry, vertex, texture, normal);
    }
    getTextureCoordinate(a) {
        if (a >= 0 && a <= 1) {
            return a;
        }
        return a - Math.floor(a);
    }
    addTexture(l, texture) {
        let t = [this.getTextureCoordinate(texture[0]), this.getTextureCoordinate(texture[1])];
        this.performer.addCut(l, t, 2);
    }
    stringToColor(str, hex) {
        if (hex)
            throw new OwnNotImplemented_1.OwnNotImplemented("Converter3DPefrormer");
        let values = [];
        for (var v of str) {
            if (v.length == 0) {
                continue;
            }
            var d = this.performer.convert(v);
            values.push(d);
        }
        return new ColorTexture_1.ColorTexture(values);
    }
    fileExists(filename, file) {
        return file.existsFile(filename);
    }
    toShiftString(str, shift) {
        var str = this.performer.toShiftString(str, shift);
        return str.replaceAll("/", "");
    }
}
exports.Converter3DPefrormer = Converter3DPefrormer;
//# sourceMappingURL=Converter3DPerformer.js.map