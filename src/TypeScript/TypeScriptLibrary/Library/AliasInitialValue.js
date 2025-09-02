"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AliasInitialValue = void 0;
const FictiveAliasName_1 = require("./Fiction/FictiveAliasName");
const FictiveVariable_1 = require("./Measurements/Variables/FictiveVariable");
class AliasInitialValue {
    getInitValue() {
        return this.value.getIValue();
    }
    resetInitValue() {
        let x = this.alias.getAliasNameValue();
        if (x != undefined) {
            this.value.setIValue(x);
        }
    }
    constructor(alias, value) {
        this.alias = new FictiveAliasName_1.FictiveAliasName();
        this.value = new FictiveVariable_1.FictiveVariable();
        this.alias = alias;
        this.value = value;
    }
}
exports.AliasInitialValue = AliasInitialValue;
//# sourceMappingURL=AliasInitialValue.js.map