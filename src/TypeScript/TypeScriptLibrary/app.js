"use strict";
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    var desc = Object.getOwnPropertyDescriptor(m, k);
    if (!desc || ("get" in desc ? !m.__esModule : desc.writable || desc.configurable)) {
      desc = { enumerable: true, get: function() { return m[k]; } };
    }
    Object.defineProperty(o, k2, desc);
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || (function () {
    var ownKeys = function(o) {
        ownKeys = Object.getOwnPropertyNames || function (o) {
            var ar = [];
            for (var k in o) if (Object.prototype.hasOwnProperty.call(o, k)) ar[ar.length] = k;
            return ar;
        };
        return ownKeys(o);
    };
    return function (mod) {
        if (mod && mod.__esModule) return mod;
        var result = {};
        if (mod != null) for (var k = ownKeys(mod), i = 0; i < k.length; i++) if (k[i] !== "default") __createBinding(result, mod, k[i]);
        __setModuleDefault(result, mod);
        return result;
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
const Performer_1 = require("./Library/Performer");
const OrbitAct_1 = require("./OrbitAct");
const Orbital_1 = require("./src/Orbital");
const readline = __importStar(require("readline"));
actT();
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});
rl.question('Is this example useful? [y/n] ', (answer) => {
    switch (answer.toLowerCase()) {
        case 'y':
            console.log('Super!');
            break;
        case 'n':
            console.log('Sorry! :(');
            break;
        default:
            console.log('Invalid answer!');
    }
    rl.close();
});
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