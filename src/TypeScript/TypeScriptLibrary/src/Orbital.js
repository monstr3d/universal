"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Orbital = void 0;
const Desktop_1 = require("../Library/Desktop");
const DataConsumer_1 = require("../Library/Measurements/DataConsumer");
const DataLink_1 = require("../Library/Measurements/DataLink");
const RandomGenerator_1 = require("../Library/Measurements/RandomGenerator");
const Recursive_1 = require("../Library/Measurements/Recursive");
const VectorFormulaConsumer_1 = require("../Library/Measurements/VectorFormulaConsumer");
class Orbital_CategoryObject_0 extends RandomGenerator_1.RandomGenerator {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Orbital_CategoryObject_1 extends RandomGenerator_1.RandomGenerator {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Orbital_CategoryObject_2 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Orbital_CategoryObject_3 extends Recursive_1.Recursive {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Orbital_CategoryObject_4 extends DataConsumer_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Orbital_CategoryArrow_0 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Orbital_CategoryArrow_1 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Orbital_CategoryArrow_2 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Orbital_CategoryArrow_3 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Orbital extends Desktop_1.Desktop {
    constructor() {
        super();
        this.name = "Orbital";
        new Orbital_CategoryObject_0(this, "X");
        new Orbital_CategoryObject_1(this, "Y");
        new Orbital_CategoryObject_2(this, "Data");
        new Orbital_CategoryObject_3(this, "Recursive");
        new Orbital_CategoryObject_4(this, "Chart");
        new Orbital_CategoryArrow_0(this, "2");
        new Orbital_CategoryArrow_1(this, "1");
        new Orbital_CategoryArrow_2(this, "3");
        new Orbital_CategoryArrow_3(this, "4");
        let arrows = this.getArrows();
        let objects = this.getObjects();
        arrows[0].setSource(objects[2]);
        arrows[0].setTarget(objects[1]);
        arrows[1].setSource(objects[2]);
        arrows[1].setTarget(objects[0]);
        arrows[2].setSource(objects[3]);
        arrows[2].setTarget(objects[2]);
        arrows[3].setSource(objects[4]);
        arrows[3].setTarget(objects[3]);
        objects[2].PostSetArrow();
        objects[3].PostSetArrow();
    }
}
exports.Orbital = Orbital;
//# sourceMappingURL=Orbital.js.map