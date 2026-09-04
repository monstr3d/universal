import type { HistoryMessage } from "./HistoryMessage";

export interface ITradingDatabaseHistoryInterface {

    getSymbolsAsync(): Promise<string[][]>

    getHistoricalDataMessageDateTimesAsync(id: any, symbol: string, begin: number,
        end: number, cancellation: AbortController): Promise<HistoryMessage[]>;

}