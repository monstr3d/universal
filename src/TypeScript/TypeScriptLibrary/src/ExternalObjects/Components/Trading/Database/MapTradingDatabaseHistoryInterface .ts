import { EmptyObject } from "../../../../Library/EmptyObject";
import { HistoryMessage } from "./HistoryMessage";
import { ITradingDatabaseHistoryInterface } from "./ITradingDatabaseHistoryInterface";

export class MapTradingDatabaseHistoryInterface extends EmptyObject implements ITradingDatabaseHistoryInterface {

    history: HistoryMessage[] = []


    constructor(map: any[]) {
        super("")
        this.types.push("ITradingDatabaseHistoryInterface")
        this.types.push("MapTradingDatabaseHistoryInterface")
        this.typeName = ""
        let mmap = new Map<string, string>([
            ["a", "Trading.RealTime"],
            ["b", "Trading.Low"],
            ["c", "Trading.High"],
            ["d", "Trading.Open"],
            ["e", "Trading.Close"],
            ["f", "Trading.Candle"],
            ["g", "Trading.Step"],
            ["h", "Trading.DateTime"]])
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
            }
            this.history.push(h)

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

    s : string[][] = []

    getSymbolsAsync(): Promise<string[][]> {
        return new Promise<string[][]>((resolve, reject) => {
            resolve(this.s)
            this.any = reject
        })
    }
    getHistoricalDataMessageDateTimesAsync(id: any, symbol: string, begin: number, end: number, cancellation: AbortController): Promise<HistoryMessage[]> {
        this.any = id;
        return new Promise<HistoryMessage[]>((resolve, reject) => {
            resolve(this.history)
            this.any = reject
        })

    }

    any : any

}