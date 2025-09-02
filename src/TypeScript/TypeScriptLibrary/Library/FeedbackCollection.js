"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FeedbackCollection = void 0;
const Performer_1 = require("./Performer");
class FeedbackCollection {
    constructor(map) {
        this.performer = new Performer_1.Performer();
        this.feedbacks = [];
        this.map = new Map();
        this.performer.copyMap(map, this.map);
    }
    getFeedbacks() {
        return this.feedbacks;
    }
    setFeedbacks() {
        for (let feedback of this.feedbacks) {
            feedback.setFeedback();
        }
    }
    getFeedbacksMap() {
        return this.map;
    }
    addFeedback(feedback) {
        this.feedbacks.push(feedback);
    }
}
exports.FeedbackCollection = FeedbackCollection;
//# sourceMappingURL=FeedbackCollection.js.map