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
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
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
const OrbitalForecastCalculation_1 = require("../../Algorithms/OrbitalForecastCalculation/OrbitalForecastCalculation");
const FeedBackFormulaAct_1 = require("../Wrappers/FeedBackFormulaAct");
const RecursvieFeedbackAct_1 = require("../Wrappers/RecursvieFeedbackAct");
const RecursiveFeedbackSimpleAct_1 = require("../Wrappers/RecursiveFeedbackSimpleAct");
const ODE_FeedAcs_1 = require("../Wrappers/ODE_FeedAcs");
const DateTimeConverter_1 = require("../../Library/Utilities/DateTime/DateTimeConverter");
const DenstyAct_1 = require("../Wrappers/DenstyAct");
const PefrormerMeasuremets_1 = require("../../Library/Measurements/PefrormerMeasuremets");
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
    finish(e) {
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
    actOrbitCalculation(b) {
        return __awaiter(this, void 0, void 0, function* () {
            var o = new OrbitalForecastCalculation_1.OrbitalForecastCalculation();
            const cond = {
                Begin: 1770457504, End: 18000, X: -5448.34815324, Y: -4463.93698421, Z: 0, Vx: -0.98539477743, Vy: 1.21681893834, Vz: 7.45047785592
            };
            o.set(cond);
            if (b) {
                var ab = new AbortController();
                const t = yield o.calculate(cond, ab);
                console.log(t);
            }
            else {
                let dc = o.getCategoryObject("Chart");
                let p = new PefrormerMeasuremets_1.PefrormerMeasuremets();
                o.set(cond);
                o.performFixedStepCalculation();
                const list = o.getResult();
                console.log(list);
                //    let m = this.getCategoryObject("A-transformation") as unknown as IMeasurements;
                //   this.measurement = m.getMeasurement(0);
            }
            console.log("finish");
        });
    }
    actDensity() {
        try {
            var o = new DenstyAct_1.DensityAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }
    }
    actTime() {
        console.log(new Date(0));
        var x = new DateTimeConverter_1.DateTimeConverter();
        console.log(x.fromOADate(0));
        var t = 1770463387;
        t = t / (24 * 60 * 60);
        console.log(t);
        var d = x.fromOADate(t);
        console.log(d);
        console.log(x.toOADate(d));
    }
    actFeedbackFormula() {
        try {
            var o = new FeedBackFormulaAct_1.FeedBackFormulaAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }
    }
    actODE_FeedAct() {
        try {
            var o = new ODE_FeedAcs_1.ODE_FeedAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }
    }
    actRecursiveFeedback() {
        try {
            var o = new RecursvieFeedbackAct_1.RecursvieFeedbackAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }
    }
    actRecursiveFeedbackSimplw() {
        try {
            var o = new RecursiveFeedbackSimpleAct_1.RecursiveFeedbackSimpleAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }
    }
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