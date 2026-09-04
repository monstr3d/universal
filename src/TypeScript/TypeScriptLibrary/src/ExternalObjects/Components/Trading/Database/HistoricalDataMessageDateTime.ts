export interface HistoricalDataMessageDateTime {
    date: number;
    open: number;
    high: number;
    low: number;
    close: number;
    volume: number;
    count: number;
    wap: number;
    hasGaps: boolean;
}