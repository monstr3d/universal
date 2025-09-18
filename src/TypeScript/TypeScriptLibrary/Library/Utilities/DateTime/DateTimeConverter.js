"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DateTimeConverter = void 0;
class DateTimeConverter {
    constructor() {
        this.baseOADate = new Date(1899, 12, 30, 0, 0, 0, 0);
        this.baseDate = new Date(0);
        this.baseDays = 25569;
        this.coeff = 86400000;
        this.coeffI = 1.0 / 86400000.0;
    }
    /*  constructor()
      {
          var x = this.baseOADate.getTime();
          this.baseDays = x * this.coeffI - 2;
      }*/
    toOADate(date) {
        var x = date.getTime() * this.coeffI;
        return x - this.baseDays;
    }
    fromOADate(date) {
        var x = date - this.baseDays;
        x *= this.coeff;
        var d = new Date();
        var off = d.getTimezoneOffset() * 60000;
        return new Date(x + off);
    }
}
exports.DateTimeConverter = DateTimeConverter;
//# sourceMappingURL=DateTimeConverter.js.map