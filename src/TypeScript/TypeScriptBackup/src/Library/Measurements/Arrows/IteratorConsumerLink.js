"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.IteratorConsumerLink = void 0;
const CategoryArrow_1 = require("../../CategoryArrow");
class IteratorConsumerLink extends CategoryArrow_1.CategoryArrow {
    setSource(source) {
        super.setSource(source);
        this.consumer = source;
    }
    /**
     * @param target
     */
    setTarget(target) {
        super.setTarget(target);
        this.iterator = target;
        this.consumer.addIterator(this.iterator);
    }
}
exports.IteratorConsumerLink = IteratorConsumerLink;
//# sourceMappingURL=IteratorConsumerLink.js.map