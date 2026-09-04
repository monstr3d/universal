"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DateTimeConverter = void 0;
class DateTimeConverter {
    baseDays = 25569;
    coeff = 86400000;
    coeffI = 1.0 / 86400000.0;
    off = 0;
    constructor() {
        //  this.baseOADate = new Date(1899, 12, 30, 0, 0, 0, 0);
        const baseDate = new Date(0);
        this.off = baseDate.getTimezoneOffset() * 60000;
    }
    toOADate(date) {
        var t = date.getTime();
        t *= this.coeffI;
        t += this.baseDays;
        return t;
    }
    fromOADate(date) {
        var x = date - this.baseDays;
        x *= this.coeff;
        return new Date(x + this.off);
    }
    fromSrting(s) {
        return Date.parse(s);
    }
}
exports.DateTimeConverter = DateTimeConverter;
