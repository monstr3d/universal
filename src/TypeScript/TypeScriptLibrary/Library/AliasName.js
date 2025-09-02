"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AliasName = void 0;
const FictiveAlias_1 = require("./Fiction/FictiveAlias");
class AliasName {
    constructor(alias, name) {
        this.alias = new FictiveAlias_1.FictiveAlias();
        this.name = "";
        this.alias = alias;
        this.name = name;
    }
    getAlias() {
        return this.alias;
    }
    getAliasNameValue() {
        return this.alias.getAliasValue(this.name);
    }
    setAliasNameValue(value) {
        if (value != undefined) {
            this.alias.setAliasValue(this.name, value);
        }
    }
    getNameOfAliasName() {
        return this.name;
    }
}
exports.AliasName = AliasName;
//# sourceMappingURL=AliasName.js.map