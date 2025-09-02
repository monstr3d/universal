"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FeedbackAlias = void 0;
const FictiveAliasName_1 = require("./Fiction/FictiveAliasName");
const FictiveValue_1 = require("./Fiction/FictiveValue");
class FeedbackAlias {
    constructor(alias, value) {
        this.value = new FictiveValue_1.FictiveValue();
        this.alias = new FictiveAliasName_1.FictiveAliasName();
        this.alias = alias;
        this.value = value;
    }
    setFeedback() {
        var x = this.value.getIValue();
        if (x != undefined) {
            this.alias.setAliasNameValue(x);
        }
    }
    getFeedBackAlias() {
        return this.alias;
    }
}
exports.FeedbackAlias = FeedbackAlias;
//# sourceMappingURL=FeedbackAlias.js.map