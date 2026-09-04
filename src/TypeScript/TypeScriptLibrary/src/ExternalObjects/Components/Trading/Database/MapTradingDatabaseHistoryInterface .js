"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.MapTradingDatabaseHistoryInterface = void 0;
const EmptyObject_1 = require("../../../../Library/EmptyObject");
class MapTradingDatabaseHistoryInterface extends EmptyObject_1.EmptyObject {
    history = [];
    constructor(map) {
        super("");
        this.types.push("ITradingDatabaseHistoryInterface");
        this.types.push("MapTradingDatabaseHistoryInterface");
        this.typeName = "";
        let mmap = new Map([
            ["a", "Trading.RealTime"],
            ["b", "Trading.Low"],
            ["c", "Trading.High"],
            ["d", "Trading.Open"],
            ["e", "Trading.Close"],
            ["f", "Trading.Candle"],
            ["g", "Trading.Step"],
            ["h", "Trading.DateTime"]
        ]);
        for (let x of map) {
            let h = {
                requestId: 0,
                date: x.a,
                open: x.d,
                high: x.c,
                low: x.b,
                close: x.e,
                volume: 0,
                count: 0,
                wap: 0,
                hasGaps: false
            };
            this.history.push(h);
        }
    }
    /*
    export interface HistoryMessage {
    requestId: number
    date: number
    open: number
    high: number
    low: number
    close: number
    volume: number
    count: number
    wap: number
    hasGaps: boolean
}
    */
    s = [];
    getSymbolsAsync() {
        return new Promise((resolve, reject) => {
            resolve(this.s);
            this.any = reject;
        });
    }
    getHistoricalDataMessageDateTimesAsync(id, symbol, begin, end, cancellation) {
        this.any = id;
        return new Promise((resolve, reject) => {
            resolve(this.history);
            this.any = reject;
        });
    }
    any;
}
exports.MapTradingDatabaseHistoryInterface = MapTradingDatabaseHistoryInterface;
