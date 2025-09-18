"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AliasInitialValue = void 0;
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
        this.alias = alias;
        this.value = value;
    }
}
exports.AliasInitialValue = AliasInitialValue;
//# sourceMappingURL=AliasInitialValue.js.map