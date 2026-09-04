"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EngineWatch = void 0;
const AbstracrtEngine_1 = require("./AbstracrtEngine");
class EngineWatch extends AbstracrtEngine_1.AbstractEngine {
    constructor(interval) {
        super(interval);
    }
    setEngineEnabled(enabled) {
        if (enabled == this.enabled)
            return false;
        this.enabled = enabled;
        if (enabled) {
            const tick = () => {
                var t = this.currentTime() - this.start;
                this.setTime(t);
            };
            this.start = this.currentTime();
            this.timerID = setInterval(() => tick(), this.interval);
        }
        else {
            clearInterval(this.timerID);
        }
        return true;
    }
    timerID = 0;
}
exports.EngineWatch = EngineWatch;
