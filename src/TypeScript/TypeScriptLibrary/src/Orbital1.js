"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Orbital1 = void 0;
const DataLink_1 = require("../Library/Measurements/DataLink");
const VectorFormulaConsumer_1 = require("../Library/Measurements/VectorFormulaConsumer");
const Desktop_1 = require("../Library/Desktop");
class Orbital1_CategoryObject_0 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Orbital1_CategoryObject_1 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Orbital1_CategoryArrow_0 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Orbital1 extends Desktop_1.Desktop {
    constructor() {
        super();
        new Orbital1_CategoryObject_0(this, "input");
        new Orbital1_CategoryObject_1(this, "Output");
        new Orbital1_CategoryArrow_0(this, "1");
        let arrows = this.getArrows();
        let objects = this.getObjects();
        arrows[0].setSource(objects[1]);
        arrows[0].setTarget(objects[0]);
        objects[0].PostSetArrow();
        objects[1].PostSetArrow();
    }
}
exports.Orbital1 = Orbital1;
//# sourceMappingURL=Orbital1.js.map