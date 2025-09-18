"use strict";
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
Object.defineProperty(exports, "__esModule", { value: true });
exports.AliasName = void 0;
class AliasName {
    constructor(alias, name) {
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