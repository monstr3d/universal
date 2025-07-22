"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const Performer_1 = require("./Library/Performer");
const OrbitAct_1 = require("./OrbitAct");
const Orbital_1 = require("./src/Orbital");
actT();
function load() {
    try {
        let orb = new Orbital_1.Orbital();
        let objs = orb.getObjects();
        let p = new Performer_1.Performer();
        var al = p.select(objs, "IAlias");
        var ln = p.select(objs, "DataLink");
        var dl = p.select(objs, "ICategoryArrow");
        let i = 0;
    }
    catch (e) {
        let ii = 0;
        ii++;
    }
}
function actT() {
    try {
        var o = new OrbitAct_1.OrbitAct();
        o.test();
    }
    catch (e) {
        var i = 0;
    }
}
//# sourceMappingURL=app.js.map