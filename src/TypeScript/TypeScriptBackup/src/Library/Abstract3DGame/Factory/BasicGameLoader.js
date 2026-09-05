"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.BasicGameLoader = void 0;
const Performer_1 = require("../../Performer");
class BasicGameLoader extends Performer_1.Performer {
    loadObject(parent, child) {
        this.scene = this.convertObject(parent, "IScene")[0];
        this.object = child;
    }
}
exports.BasicGameLoader = BasicGameLoader;
//# sourceMappingURL=BasicGameLoader.js.map