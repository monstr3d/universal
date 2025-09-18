"use strict";
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
Object.defineProperty(exports, "__esModule", { value: true });
exports.FeedbackAlias = void 0;
class FeedbackAlias {
    constructor(alias, value) {
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