"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AliasName = void 0;
class AliasName {
    constructor(alias, name) {
        this.name = "";
        this.alias = alias;
        this.name = name;
    }
    getAliasNameValue() {
        return this.alias.getAliasValue(this.name);
    }
    setAliasNameValue(value) {
    }
    getAliasBase() {
        return this.alias;
    }
    getNameOfAliasName() {
        return this.name;
    }
}
exports.AliasName = AliasName;
//# sourceMappingURL=AliasName.js.map