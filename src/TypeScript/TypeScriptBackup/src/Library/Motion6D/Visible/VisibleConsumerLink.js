"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.VisibleConsumerLink = void 0;
const CategoryArrow_1 = require("../../CategoryArrow");
class VisibleConsumerLink extends CategoryArrow_1.CategoryArrow {
    constructor(desktop, name) {
        super(desktop, name);
        this.typeName = "VisibleConsumerLink";
        this.types.push("VisibleConsumerLink");
    }
    getSource() {
        return this.consumer;
    }
    getTagret() {
        return this.visible;
    }
    setSource(source) {
        var c = this.performer.convertProperties(source, "IVisibleConsumer");
        this.consumer = c[0];
    }
    setTarget(target) {
        this.visible = this.performer.convertProperties(target, "IVisible")[0];
        this.consumer.addVisibleObject(this.visible);
    }
}
exports.VisibleConsumerLink = VisibleConsumerLink;
//# sourceMappingURL=VisibleConsumerLink.js.map