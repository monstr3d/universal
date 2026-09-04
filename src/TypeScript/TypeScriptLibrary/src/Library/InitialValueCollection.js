"use strict";
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
Object.defineProperty(exports, "__esModule", { value: true });
exports.InitialValueCollection = void 0;
class InitialValueCollection {
    addInitialValue(value) {
        this.values.push(value);
    }
    getInitialValues() {
        return this.values;
    }
    resetInitialValues() {
        for (var item of this.values) {
            item.resetInitValue();
        }
    }
    values = [];
}
exports.InitialValueCollection = InitialValueCollection;
