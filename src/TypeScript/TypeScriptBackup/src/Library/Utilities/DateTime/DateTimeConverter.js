"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DateTimeConverter = void 0;
class DateTimeConverter {
    constructor() {
        this.baseDays = 25569;
        this.coeff = 86400000;
        this.coeffI = 1.0 / 86400000.0;
        this.off = 0;
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
//# sourceMappingURL=DateTimeConverter.js.map