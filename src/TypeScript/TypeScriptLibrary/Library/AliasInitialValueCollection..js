"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AliasInitialValueCollection = void 0;
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
const AliasInitialValue_1 = require("./AliasInitialValue");
const AliasName_1 = require("./AliasName");
const InitialValueCollection_1 = require("./InitialValueCollection");
const Performer_1 = require("./Performer");
class AliasInitialValueCollection extends InitialValueCollection_1.InitialValueCollection {
    constructor(alias, measurements) {
        super();
        this.performer = new Performer_1.Performer();
        var n = measurements.getMeasurementsCount();
        for (let i = 0; i < n; i++) {
            var m = measurements.getMeasurement(i);
            var name = m.getMeasurementName();
            var iv = this.performer.convertObject(m, "IValue");
            var an = new AliasName_1.AliasName(alias, name);
            if (iv.length == 1) {
                var init = new AliasInitialValue_1.AliasInitialValue(an, iv[0]);
                this.addInitialValue(init);
            }
        }
    }
}
exports.AliasInitialValueCollection = AliasInitialValueCollection;
//# sourceMappingURL=AliasInitialValueCollection..js.map