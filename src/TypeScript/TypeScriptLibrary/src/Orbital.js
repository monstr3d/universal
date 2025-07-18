"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Orbital = void 0;
const Desktop_1 = require("../Library/Desktop");
const VectorFormulaConsumer_1 = require("../Library/Measurements/VectorFormulaConsumer");
class Orbital_CategoryObject_0 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        let map = new Map([
            ["b", 1],
            ["a", 5]
        ]);
        this.performer.SetAliasMap(map, this);
    }
}
class Orbital extends Desktop_1.Desktop {
    constructor() {
        super();
        this.name = "Orbital";
        new Orbital_CategoryObject_0(this, "input");
        let arrows = this.getArrows();
        let objects = this.getObjects();
        objects[0].PostSetArrow();
    }
}
exports.Orbital = Orbital;
//# sourceMappingURL=Orbital.js.map