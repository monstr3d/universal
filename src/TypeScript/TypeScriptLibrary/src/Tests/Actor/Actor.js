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
exports.finish = finish;
//import { Airplane } from '../../Airplane';
const fs = __importStar(require("node:fs"));
const OrbitalData_1 = require("../../ExternalObjects/Algorithms/OrbitalForecastCalculation/OrbitalData");
const OrbitalForecastCalculation_1 = require("../../ExternalObjects/Algorithms/OrbitalForecastCalculation/OrbitalForecastCalculation");
const MapTradingDatabaseHistoryInterface_1 = require("../../ExternalObjects/Components/Trading/Database/MapTradingDatabaseHistoryInterface ");
const StreamReader_1 = require("../../FileSystem/IO/StreamReader");
const PerformerMeasuremets_1 = require("../../Library/Measurements/PerformerMeasuremets");
const Motion6DFactory_1 = require("../../Library/Motion6D/Motion6DFactory");
const UniversalFactory_1 = require("../../Library/UniversalFactory");
const DateTimeConverter_1 = require("../../Library/Utilities/DateTime/DateTimeConverter");
const Donchian_1 = require("../Donchian");
const ComposionAct_1 = require("../Wrappers/ComposionAct");
const ConditionTestAct_1 = require("../Wrappers/ConditionTestAct");
const DenstyAct_1 = require("../Wrappers/DenstyAct");
const FeedBackFormulaAct_1 = require("../Wrappers/FeedBackFormulaAct");
const ODE_FeedAcs_1 = require("../Wrappers/ODE_FeedAcs");
const ODE_FeedbackAct_1 = require("../Wrappers/ODE_FeedbackAct");
const ODEAct_1 = require("../Wrappers/ODEAct");
const OrbitAct_1 = require("../Wrappers/OrbitAct");
const OrbitalForecastAct_1 = require("../Wrappers/OrbitalForecastAct");
const PIAct_1 = require("../Wrappers/PIAct");
const RandomAcr_1 = require("../Wrappers/RandomAcr");
const RecursiveFeedbackSimpleAct_1 = require("../Wrappers/RecursiveFeedbackSimpleAct");
const RecursvieFeedbackAct_1 = require("../Wrappers/RecursvieFeedbackAct");
const SimpleFeedAct_1 = require("../Wrappers/SimpleFeedAct");
const TwoAct_1 = require("../Wrappers/TwoAct");
const EmptyChecker_1 = require("../../Library/EmptyChecker");
const DonchianDesktopAct_1 = require("../Wrappers/DonchianDesktopAct");
class Actor {
    testRecursive() {
        var r = new DonchianDesktopAct_1.DonchianDesktopAct();
        r.test();
    }
    async actDonchian() {
        let controller = new AbortController();
        let db = this.getTradingFromFile("C:\\0\\0\\1.json");
        let f = new UniversalFactory_1.UniversalFactory;
        f.addFactory(db, "ITradingDatabaseHistoryInterface");
        f.addFactory(new EmptyChecker_1.EmptyChecker(), "ICheck");
        let desktop = await Donchian_1.Donchian.getDesktop(controller, f);
        let pefrormer = new PerformerMeasuremets_1.PerformerMeasuremets(new UniversalFactory_1.UniversalFactory());
        let query = desktop.getCategoryObject("Trading");
        let dataConsumer = desktop.getCategoryObject("Chart");
        let mmap = new Map([
            ["a", "Trading.RealTime"],
            ["b", "Trading.Low"],
            ["c", "Trading.High"],
            ["d", "Trading.Open"],
            ["e", "Trading.Close"],
            ["f", "Trading.Candle"],
            ["g", "Trading.Step"],
            ["h", "Trading.DateTime"],
            ["i", "Order.Position"],
            ["j", "Order.Income"],
            ["k", "Order.Sell Price"],
            ["l", "Order.Buy Price"],
            ["m", "Average Short.Output"],
            ["n", "Averge Long.Output"],
            ["o", "Donchian minimum long.Output"],
            ["p", "Donchian minimum short.Output"],
            ["q", "Donchian maximum long.Output"],
            ["r", "Donchian maximum short.Output"]
        ]);
        /* let x = await pefrormer.performIteratorDataConsumerMapAsync(dataConsumer,
             query, controller, mmap);
         let y = x[0]
         let z = x[x.length-1]
         finish(desktop);*/
    }
    factory = new Motion6DFactory_1.Motion6DFactory();
    constructor() {
    }
    finish(e) {
        /*   rl.question('Is this example useful? [y/n] ', (answer) => {
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
           });*/
    }
    /*
        public loadObj(filename: string): void {
            var fact = new UniversalFactory()
            var ff = new FileSystemFactory()
            ff.setFactory(fact)
            var ss = new LineEndSplitter()
            fact.addFactory<IStringSplitter>(ss, "IStringSplitter")
            var creator = new Obj3DCreator(filename, "", undefined, fact)
            var m = creator.getMeshCreatorMeshes()
            console.log(m)
        }
    
    
        */
    readTest(f) {
        let reader = new StreamReader_1.StreamReader(f);
        let s = reader.readToEnd();
        console.log(s);
    }
    getTradingFromFile(f) {
        MapTradingDatabaseHistoryInterface_1.MapTradingDatabaseHistoryInterface;
        let text = fs.readFileSync(f, "utf-8");
        let x = JSON.parse(text);
        let y = x;
        return new MapTradingDatabaseHistoryInterface_1.MapTradingDatabaseHistoryInterface(y);
    }
    /*
    public async actDonchianLoad(): Promise<void> {
     /*   TradingDataQuery.inter = new TradingHistoryFetchDatabase();
        var d = new Donchian();
        var ac = new AbortController();
        await d.loadAsync(ac);
    }*/
    actCompositionAct() {
        var comp = new ComposionAct_1.CompositionAct();
        comp.test();
    }
    actAirplane() {
        //  new Airplane()
    }
    actCompositionEvent(stop) {
        //  var comp = new CompositionEvent(stop)
        // comp.test();
    }
    testDate() {
        var dt = new DateTimeConverter_1.DateTimeConverter();
    }
    async actOrbitCalculation(b) {
        var o = new OrbitalForecastCalculation_1.OrbitalForecastCalculation();
        var bb = 1770457504;
        const cond = {
            begin: bb, end: bb + 18000, x: -5448.34815324, y: -4463.93698421, z: 0, vx: -0.98539477743, vy: 1.21681893834, vz: 7.45047785592
        };
        o.set(cond);
        if (b) {
            var ab = new AbortController();
            const t = await o.calculate(cond, ab);
            for (var x of t) {
                var y = (0, OrbitalData_1.toDateTime)(x);
                console.log(y);
            }
        }
        else {
            let dc = o.getCategoryObject("Chart");
            let p = new PerformerMeasuremets_1.PerformerMeasuremets();
            o.set(cond);
            o.performFixedStepCalculation();
            const list = o.getResult();
            console.log(list);
            //    let m = this.getCategoryObject("A-transformation") as unknown as IMeasurements;
            //   this.measurement = m.getMeasurement(0);
        }
        console.log("finish");
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
            //    var o = new TransformerRecursveAct();
            //   o.test();
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
        }
    }
    actComposition() {
        try {
            var o = new ComposionAct_1.CompositionAct();
            o.test();
        }
        catch (e) {
            console.log(e);
        }
    }
    actRandom() {
        try {
            var o = new RandomAcr_1.RandomAct();
            o.test();
        }
        catch (e) {
            console.log(e);
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
function finish(e) {
    console.log(e);
    /* rl.question('Is this example useful? [y/n] ', (answer) => {
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
       //   rl.close();
     // });
     */
}
