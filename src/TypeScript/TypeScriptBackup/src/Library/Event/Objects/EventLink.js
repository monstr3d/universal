"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EventLink = void 0;
const CategoryArrow_1 = require("../../CategoryArrow");
const OwnNotImplemented_1 = require("../../ErrorHandler/OwnNotImplemented");
class EventLink extends CategoryArrow_1.CategoryArrow {
    constructor(desktop, name) {
        super(desktop, name);
    }
    setSource(source) {
        var h = this.getObjectT(source, "IEventHandler");
        if (h.length == 0) {
            throw new OwnNotImplemented_1.OwnNotImplemented("EVENT LINK");
        }
        this.handler = h[0];
        super.setSource(source);
    }
    setTarget(target) {
        this.target = target;
        var e = this.getObjectT(target, "IEvent");
        if (e.length == 0) {
            throw new OwnNotImplemented_1.OwnNotImplemented("Event link");
        }
        this.event = e[0];
        this.handler.addEventToHandler(e[0]);
        super.setTarget(target);
    }
}
exports.EventLink = EventLink;
//# sourceMappingURL=EventLink.js.map