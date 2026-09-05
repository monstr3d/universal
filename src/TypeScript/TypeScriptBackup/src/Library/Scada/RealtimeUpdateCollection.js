"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RealtimeUpdateCollection = void 0;
const ActionArrayT_1 = require("../Utilities/Generic/ActionArrayT");
const Performer_1 = require("../Performer");
class RealtimeUpdateCollection {
    getRealtimeUpdate() {
        return this.action;
    }
    constructor(collection) {
        this.pefrormer = new Performer_1.Performer();
        this.action = new ActionArrayT_1.ActionArrayT();
        this.pefrormer.forEach(collection, this, "IRealtimeUpdate");
    }
    actionT(t) {
        this.action.addActionT(t.getRealtimeUpdate());
    }
    isEmptyActionT() { return false; }
}
exports.RealtimeUpdateCollection = RealtimeUpdateCollection;
//# sourceMappingURL=RealtimeUpdateCollection.js.map