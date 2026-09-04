"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TradingDataQuery = void 0;
const CategoryObject_1 = require("../../../Library/CategoryObject");
const Measurement_1 = require("../../../Library/Measurements/Measurement");
const DateTimeConverter_1 = require("../../../Library/Utilities/DateTime/DateTimeConverter");
class TradingDataQuery extends CategoryObject_1.CategoryObject {
    inter;
    vector = [0, 0, 0, 0];
    symbols = new Map();
    realTime = 0;
    measurements = [];
    factory;
    constructor(desktop, name) {
        super(desktop, name);
        let t = this.performer.convertObject(desktop, "IFactoryConsumer");
        if (t.length > 0) {
            this.factory = t[0].getConsumerFactory();
            if (this.factory !== undefined) {
                let i = this.factory.getFactory("ITradingDatabaseHistoryInterface");
                if (i !== undefined)
                    this.inter = i;
            }
        }
        this.typeName = "TradingDataQuery";
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
    async startAsync(controller) {
        this.data = await this.inter.getHistoricalDataMessageDateTimesAsync("", this.symbol, this.begin, this.end, controller);
    }
    getMeasurementsCount() {
        return this.measurements.length;
    }
    getMeasurement(i) {
        return this.measurements[i];
    }
    updateMeasurements() {
    }
    addMeasurement(measurement) {
        this.any = measurement;
    }
    nextIterator() {
        ++this.step;
        if (this.step >= this.data.length)
            return false;
        this.current = this.data[this.step];
        this.fillVector();
        return true;
    }
    resetIterator() {
        this.step = 0;
    }
    fillVector() {
        this.vector[0] = this.current.high;
        this.vector[1] = this.current.low;
        this.vector[2] = this.current.open;
        this.vector[3] = this.current.close;
    }
    async initializeTaskAsync(controller) {
        var sym = await this.inter.getSymbolsAsync();
        for (let i of sym) {
            this.symbols.set(i[0], i[1]);
        }
        this.symbolsstr = sym;
        this.any = controller;
    }
    getSymbolsStr() {
        return this.symbolsstr;
    }
    setQueryParameters(symbol, period, begin, end) {
        this.symbol = symbol;
        this.period = period;
        this.begin = begin;
        this.end = end;
    }
    any;
    id;
    begin = 0;
    end = 0;
    period = "";
    symbol = "";
    data = [];
    current;
    step = 0;
    symbolsstr = [];
}
exports.TradingDataQuery = TradingDataQuery;
class BasicMeasurement extends Measurement_1.Measurement {
    query;
    constructor(name, type, query) {
        super(name, type);
        this.query = query;
    }
    getAssociatedObject() {
        return this.query;
    }
    setAssociatedObject(obj) {
        this.any = obj;
    }
    any;
}
class LowMeasurement extends BasicMeasurement {
    constructor(query) {
        super("Low", 0, query);
    }
    getMeasurementValue() {
        return this.query.current.low;
    }
}
class HighMeasurement extends BasicMeasurement {
    constructor(query) {
        super("High", 0, query);
    }
    getMeasurementValue() {
        return this.query.current.high;
    }
}
class OpenMeasurement extends BasicMeasurement {
    constructor(query) {
        super("Open", 0, query);
    }
    getMeasurementValue() {
        return this.query.current.open;
    }
}
class CloseMeasurement extends BasicMeasurement {
    constructor(query) {
        super("Close", 0, query);
    }
    getMeasurementValue() {
        return this.query.current.close;
    }
}
class RealTimeMeasurement extends BasicMeasurement {
    constructor(query) {
        super("RealTime", 0, query);
    }
    getMeasurementValue() {
        return this.query.realTime;
    }
}
class IntegerTimeMeasurement extends BasicMeasurement {
    constructor(query) {
        super("Step", 0, query);
    }
    getMeasurementValue() {
        return this.query.step;
    }
}
class DateTimeMeasurement extends BasicMeasurement {
    constructor(query) {
        super("DateTime", 0, query);
    }
    getMeasurementValue() {
        return this.query.current.date;
    }
}
class FullTimeMeasurement extends BasicMeasurement {
    converter = new DateTimeConverter_1.DateTimeConverter;
    constructor(query) {
        super("FullTime", 0, query);
    }
    getMeasurementValue() {
        var d = this.query.current.date;
        if (d == undefined) {
            return undefined;
        }
        return d;
    }
}
class CandleMeasurement extends BasicMeasurement {
    constructor(query) {
        super("Candle", 0, query);
        this.type = [0, 0, 0, 0];
    }
    getMeasurementValue() {
        return this.query.vector;
    }
}
