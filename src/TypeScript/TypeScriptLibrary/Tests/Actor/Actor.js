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
exports.Actor = void 0;
const readline = __importStar(require("readline"));
const ConditionTestAct_1 = require("../Wrappers/ConditionTestAct");
const ODEAct_1 = require("../Wrappers/ODEAct");
const OrbitAct_1 = require("../Wrappers/OrbitAct");
const RandomAcr_1 = require("../Wrappers/RandomAcr");
const SimpleFeedAct_1 = require("../Wrappers/SimpleFeedAct");
const TwoAct_1 = require("../Wrappers/TwoAct");
const ODE_FeedbackAct_1 = require("../Wrappers/ODE_FeedbackAct");
const TransformerRecursveAct_1 = require("../Wrappers/TransformerRecursveAct");
const PIAct_1 = require("../Wrappers/PIAct");
const OrbitalForecastAct_1 = require("../Wrappers/OrbitalForecastAct");
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});
function finish(e) {
    console.log(e);
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
}
class Actor {
    actODEFeedback() {
        try {
            var o = new ODE_FeedbackAct_1.ODE_FeedbackAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }
    }
    actOrbitalForecast() {
        try {
            var o = new OrbitalForecastAct_1.OrbitaForecasAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }
    }
    actTransformerFeedback() {
        try {
            var o = new TransformerRecursveAct_1.TransformerRecursveAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }
    }
    actODE() {
        try {
            var o = new ODEAct_1.ODEAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }
    }
    actCondition() {
        try {
            var o = new ConditionTestAct_1.ConditionTestAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }
    }
    actPI() {
        try {
            var o = new PIAct_1.PIAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }
    }
    actTestObjectTransformerSimple() {
        try {
            /*  var o = new TestObjectTransformerSimpleAct();
              o.test();*/
        }
        catch (e) {
            finish(e);
        }
    }
    actSimpleFeed() {
        try {
            var o = new SimpleFeedAct_1.SimpleFeedAct();
            o.test();
        }
        catch (e) {
            console.log(e);
        }
    }
    actTwo() {
        try {
            var o = new TwoAct_1.TwoAct();
            o.test();
        }
        catch (e) {
            console.log(e);
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
        }
    }
    actRandom() {
        try {
            var o = new RandomAcr_1.RandomAct();
            o.test();
        }
        catch (e) {
            console.log(e);
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
        }
    }
    actOrbit() {
        try {
            var o = new OrbitAct_1.OrbitAct();
            o.test();
        }
        catch (e) {
            var i = 0;
        }
    }
}
exports.Actor = Actor;
//# sourceMappingURL=Actor.js.map