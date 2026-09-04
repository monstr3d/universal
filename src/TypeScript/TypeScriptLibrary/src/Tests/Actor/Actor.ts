

import { RungeProcessor } from '../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor';
import { DataRuntimeConsumerODE } from '../../Library/Runtime/DataRuntimeConsumerODE';
import { CompositionEvent } from '../Wrappers/CompositionEvent';

import { Composition } from '../Composition';

//import { Airplane } from '../../Airplane';

import * as fs from 'node:fs';
import { toDateTime } from '../../ExternalObjects/Algorithms/OrbitalForecastCalculation/OrbitalData';
import { OrbitalForecastCalculation } from '../../ExternalObjects/Algorithms/OrbitalForecastCalculation/OrbitalForecastCalculation';
import { ITradingDatabaseHistoryInterface } from '../../ExternalObjects/Components/Trading/Database/ITradingDatabaseHistoryInterface';
import { MapTradingDatabaseHistoryInterface } from '../../ExternalObjects/Components/Trading/Database/MapTradingDatabaseHistoryInterface ';
import { TradingDataQuery } from '../../ExternalObjects/Components/Trading/TradingDataQuery';
import { StreamReader } from '../../FileSystem/IO/StreamReader';
import { IFactory } from '../../Library/Interfaces/IFactory';
import { IFunc } from '../../Library/Interfaces/IFunc';
import { IDataConsumer } from '../../Library/Measurements/Interfaces/IDataConsumer';
import { PerformerMeasuremets } from '../../Library/Measurements/PerformerMeasuremets';
import { Motion6DFactory } from '../../Library/Motion6D/Motion6DFactory';
import { UniversalFactory } from '../../Library/UniversalFactory';
import { DateTimeConverter } from '../../Library/Utilities/DateTime/DateTimeConverter';
import { Donchian } from '../Donchian';
import { CompositionAct } from '../Wrappers/ComposionAct';
import { ConditionTestAct } from '../Wrappers/ConditionTestAct';
import { DensityAct } from '../Wrappers/DenstyAct';
import { FeedBackFormulaAct } from '../Wrappers/FeedBackFormulaAct';
import { ODE_FeedAct } from '../Wrappers/ODE_FeedAcs';
import { ODE_FeedbackAct } from '../Wrappers/ODE_FeedbackAct';
import { ODEAct } from '../Wrappers/ODEAct';
import { OrbitAct } from '../Wrappers/OrbitAct';
import { OrbitaForecasAct } from '../Wrappers/OrbitalForecastAct';
import { PIAct } from '../Wrappers/PIAct';
import { RandomAct } from '../Wrappers/RandomAcr';
import { RecursiveFeedbackSimpleAct } from '../Wrappers/RecursiveFeedbackSimpleAct';
import { RecursvieFeedbackAct } from '../Wrappers/RecursvieFeedbackAct';
import { SimpleFeedAct } from '../Wrappers/SimpleFeedAct';
import { TwoAct } from '../Wrappers/TwoAct';
import { EmptyChecker } from '../../Library/EmptyChecker'
import { ICheck } from '../../Library/Interfaces/ICheck';
import { DonchianDesktopAct } from '../Wrappers/DonchianDesktopAct';

export class Actor {

    testRecursive(): void {
        var r = new DonchianDesktopAct()
        r.test();
    }

    async actDonchian(): Promise<void> {
        let controller = new AbortController();
        let db = this.getTradingFromFile("C:\\0\\0\\1.json");
        let f = new UniversalFactory;
        f.addFactory<ITradingDatabaseHistoryInterface>(db, "ITradingDatabaseHistoryInterface");
        f.addFactory<ICheck>(new EmptyChecker(), "ICheck");
        let desktop = await Donchian.getDesktop(controller, f);
        let pefrormer = new PerformerMeasuremets(new UniversalFactory());
        let query = desktop.getCategoryObject("Trading") as unknown as TradingDataQuery;
        let dataConsumer = desktop.getCategoryObject("Chart") as unknown as IDataConsumer;
        let mmap = new Map<string, string>([
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
        ]
        );
       /* let x = await pefrormer.performIteratorDataConsumerMapAsync(dataConsumer,
            query, controller, mmap);
        let y = x[0]
        let z = x[x.length-1]
        finish(desktop);*/
    }

    factory: IFactory = new Motion6DFactory();
    constructor() {
    }
    finish(e: any): void {
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
    public readTest(f: string): void {
        let reader = new StreamReader(f);
        let s = reader.readToEnd();
        console.log(s);
    }

    public getTradingFromFile(f: string): ITradingDatabaseHistoryInterface {
        MapTradingDatabaseHistoryInterface;
        let text = fs.readFileSync(f, "utf-8");
        let x = JSON.parse(text);
        let y = x as unknown as Map<string, any>[];
        return new MapTradingDatabaseHistoryInterface(y);

    }

    /*
    public async actDonchianLoad(): Promise<void> {
     /*   TradingDataQuery.inter = new TradingHistoryFetchDatabase();
        var d = new Donchian();
        var ac = new AbortController();
        await d.loadAsync(ac);
    }*/
    public actCompositionAct() {
        var comp = new CompositionAct();
        comp.test();

    }

    public actAirplane() {
        //  new Airplane()
    }
    public actCompositionEvent(stop: IFunc<boolean>) {
        //  var comp = new CompositionEvent(stop)
        // comp.test();
    }


    public testDate(): void {
        var dt = new DateTimeConverter();
    }

    async actOrbitCalculation(b: boolean): Promise<void> {
        var o = new OrbitalForecastCalculation();
        var bb = 1770457504;
        const cond = {
            begin: bb, end: bb + 18000, x: -5448.34815324, y: -4463.93698421, z: 0, vx: -0.98539477743, vy: 1.21681893834, vz: 7.45047785592
        };
        o.set(cond);
        if (b) {
            var ab = new AbortController();
            const t = await o.calculate(cond, ab);
            for (var x of t) {
                var y = toDateTime(x);
                console.log(y);
            }
        }
        else {
            let dc = o.getCategoryObject("Chart") as unknown as IDataConsumer;
            let p = new PerformerMeasuremets();
            o.set(cond);
            o.performFixedStepCalculation();
            const list = o.getResult();
            console.log(list);

            //    let m = this.getCategoryObject("A-transformation") as unknown as IMeasurements;
            //   this.measurement = m.getMeasurement(0);
        }
        console.log("finish");
    }

    actDensity(): void {
        try {
            var o = new DensityAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }
    }

    actTime(): void {
        console.log(new Date(0));
        var x = new DateTimeConverter();
        console.log(x.fromOADate(0));
        var t = 1770463387;
        t = t / (24 * 60 * 60);
        console.log(t);
        var d = x.fromOADate(t);
        console.log(d);
        console.log(x.toOADate(d));

    }


    actFeedbackFormula(): void {
        try {
            var o = new FeedBackFormulaAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }

    }

    actODE_FeedAct(): void {
        try {
            var o = new ODE_FeedAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }

    }


    actRecursiveFeedback(): void {
        try {
            var o = new RecursvieFeedbackAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }

    }



    actRecursiveFeedbackSimplw(): void {
        try {
            var o = new RecursiveFeedbackSimpleAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }

    }



    actODEFeedback(): void {
        try {
            var o = new ODE_FeedbackAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }

    }


    actOrbitalForecast(): void {
        try {
            var o = new OrbitaForecasAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }

    }



    actTransformerFeedback(): void {
        try {
            //    var o = new TransformerRecursveAct();
            //   o.test();
        }
        catch (e) {
            finish(e);
        }

    }


    actODE(): void {
        try {
            var o = new ODEAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }
    }

    actCondition(): void {
        try {
            var o = new ConditionTestAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }
    }

    actPI(): void {
        try {
            var o = new PIAct();
            o.test();
        }
        catch (e) {
            finish(e);
        }
    }


    actTestObjectTransformerSimple(): void {
        try {
            /*  var o = new TestObjectTransformerSimpleAct();
              o.test();*/
        }
        catch (e) {
            finish(e);
        }
    }


    actSimpleFeed(): void {
        try {
            var o = new SimpleFeedAct();
            o.test();
        }
        catch (e) {
            console.log(e);
        }
    }
    actTwo(): void {
        try {
            var o = new TwoAct();
            o.test();
        }
        catch (e) {
            console.log(e);
        }
    }

    public actComposition(): void {
        try {
            var o = new CompositionAct();
            o.test();
        }
        catch (e) {
            console.log(e);
        }
    }




    actRandom(): void {
        try {
            var o = new RandomAct();
            o.test();
        }
        catch (e) {
            console.log(e);
        }

    }

    actOrbit(): void {
        try {
            var o = new OrbitAct();
            o.test();
        }
        catch (e) {
            var i = 0;
        }
    }
}


export function finish(e : any) {
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
