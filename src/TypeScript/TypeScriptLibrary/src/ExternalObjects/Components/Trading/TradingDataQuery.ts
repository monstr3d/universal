import type { IDesktop } from "../../../Library/Interfaces/IDesktop";
import type { IInitializeTask } from "../../../Library/Interfaces/IInitializeTask";
import type { IIterator } from "../../../Library/Measurements/Interfaces/IIterator";
import type { IMeasurement } from "../../../Library/Measurements/Interfaces/IMeasurement";
import type { IMeasurements } from "../../../Library/Measurements/Interfaces/IMeasurements";
import type { ITradingDatabaseHistoryInterface } from "./Database/ITradingDatabaseHistoryInterface";
import type { IAssociatedObject } from "../../../Library/Interfaces/IAssociatedObject";
import type { IObject } from "../../../Library/Interfaces/IObject";
import type { IStartTask } from "../../../Library/Interfaces/IStartTask";
import { CategoryObject } from "../../../Library/CategoryObject";
import { Measurement } from "../../../Library/Measurements/Measurement";
import { DateTimeConverter } from "../../../Library/Utilities/DateTime/DateTimeConverter";
import { HistoricalDataMessageDateTime } from "./Database/HistoricalDataMessageDateTime";
import { IFactoryConsumer } from "../../../Library/Interfaces/IFactoryConsumer";
import { IFactory } from "../../../Library/Interfaces/IFactory";



export class TradingDataQuery extends CategoryObject implements IInitializeTask, IStartTask,
    IIterator, IMeasurements
{


    inter !: ITradingDatabaseHistoryInterface 

    vector : number[] = [0, 0, 0, 0]


    symbols: Map<string, any> = new Map<string, any>()

    realTime: number = 0

    measurements: IMeasurement[] = []

    factory !: IFactory

    constructor(desktop: IDesktop, name: string) {
        super(desktop, name)
        let t = this.performer.convertObject<IFactoryConsumer, any>(desktop, "IFactoryConsumer")
        if (t.length > 0) {
            this.factory = t[0].getConsumerFactory()
            if (this.factory !== undefined) {
                let i = this.factory.getFactory<ITradingDatabaseHistoryInterface>("ITradingDatabaseHistoryInterface")
                if (i !== undefined) this.inter = i
            }
        }
        this.typeName = "TradingDataQuery"
        this.types.push("TradingDataQuery");
        this.types.push("IInitializeTask");
        this.types.push("IIterator");
        this.types.push("IMeasurements");
        this.types.push("IStartTask");
        this.measurements =
            [
                new RealTimeMeasurement(this),
                new LowMeasurement(this),
                new HighMeasurement(this),
                new OpenMeasurement(this),
                new CloseMeasurement(this),
                new CandleMeasurement(this),
                new IntegerTimeMeasurement(this),
                new DateTimeMeasurement(this),
                new FullTimeMeasurement(this)
            ];

    }

    async startAsync(controller: AbortController): Promise<void> {
        this.data = await this.inter.getHistoricalDataMessageDateTimesAsync("", this.symbol, this.begin,
            this.end, controller)
    }

    getMeasurementsCount(): number {
        return this.measurements.length
    }

    getMeasurement(i: number): IMeasurement {
        return this.measurements[i]
    }

    updateMeasurements(): void {
        
    }

    addMeasurement(measurement: IMeasurement): void {
        this.any = measurement
    }

    nextIterator(): boolean {
        ++this.step;
        if (this.step >= this.data.length) return false
        this.current = this.data[this.step]
        this.fillVector()
        return true
    }

    resetIterator(): void {
        this.step = 0;
    }

    fillVector(): void {
        this.vector[0] = this.current.high
        this.vector[1] = this.current.low
        this.vector[2] = this.current.open
        this.vector[3] = this.current.close
    }

    async initializeTaskAsync(controller: AbortController): Promise<void> {
       var sym = await this.inter.getSymbolsAsync();
       for (let i of sym) {
           this.symbols.set(i[0], i[1])
       }
        this.symbolsstr = sym
        this.any = controller
    }

    public getSymbolsStr(): string[][] {
        return this.symbolsstr
    }

    public setQueryParameters(symbol: string, period: string, begin: number, end: number): void {
        this.symbol = symbol
        this.period = period
        this.begin = begin
        this.end = end

    }

    any : any
 
    protected id !: any;

    protected begin: number = 0;

    protected end: number = 0;

    protected period: string = "";

    protected symbol: string = "";

    data: HistoricalDataMessageDateTime[] = [];

    current !: HistoricalDataMessageDateTime;


    step: number = 0;

    symbolsstr: string[][] = []

    
}

class BasicMeasurement extends Measurement implements IAssociatedObject {

    query !: TradingDataQuery
    constructor(name: string, type: any, query: TradingDataQuery) {
        super(name, type)
        this.query = query
    }
    getAssociatedObject(): IObject {
        return this.query;
    }
    setAssociatedObject(obj: IObject): void {
        this.any = obj;
    }

    any : any

}

class LowMeasurement extends BasicMeasurement {
    constructor(query: TradingDataQuery) {
        super("Low", 0, query)
    }


    getMeasurementValue() {
        return this.query.current.low
    }

}

class HighMeasurement extends BasicMeasurement {
    constructor(query: TradingDataQuery) {
        super("High", 0, query)
    }


    getMeasurementValue() {
        return this.query.current.high
    }

}

class OpenMeasurement extends BasicMeasurement {
    constructor(query: TradingDataQuery) {
        super("Open", 0, query)
    }


    getMeasurementValue() {
        return this.query.current.open
    }

}


class CloseMeasurement extends BasicMeasurement {
    constructor(query: TradingDataQuery) {
        super("Close", 0, query)
    }


    getMeasurementValue() {
        return this.query.current.close
    }

}

class RealTimeMeasurement extends BasicMeasurement {
    constructor(query: TradingDataQuery) {
        super("RealTime", 0, query)
    }


    getMeasurementValue() {
        return this.query.realTime
    }

}

class IntegerTimeMeasurement extends BasicMeasurement
{
    constructor(query: TradingDataQuery) {
        super("Step", 0, query)
    }


    getMeasurementValue() {
        return this.query.step
    }


}

class DateTimeMeasurement extends BasicMeasurement
{
    constructor(query: TradingDataQuery) {
        super("DateTime", 0, query)
    }

    getMeasurementValue() {
        return this.query.current.date
    }

}

class FullTimeMeasurement extends BasicMeasurement
{

    converter: DateTimeConverter = new DateTimeConverter
    constructor(query: TradingDataQuery) {
        super("FullTime", 0, query)
    }
    getMeasurementValue() {
        var d = this.query.current.date;
        if (d == undefined) {
            return undefined;
        }
        return d
    }
}


class CandleMeasurement extends BasicMeasurement
{
    constructor(query: TradingDataQuery) {
        super("Candle", 0, query)
        this.type = [0, 0, 0, 0]
    }

    getMeasurementValue() {
        return this.query.vector
   
    }

}









