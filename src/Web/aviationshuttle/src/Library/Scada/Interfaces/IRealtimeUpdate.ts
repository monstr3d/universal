import type { IActionT } from "../../Interfaces/IActionT";

export interface IRealtimeUpdate {
    getRealtimeUpdate(): IActionT<number>
}