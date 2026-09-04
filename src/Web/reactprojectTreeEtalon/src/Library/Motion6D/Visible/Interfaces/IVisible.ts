import type { IPositionObject } from "../../Interfaces/IPositionObject";
import type { ISaveGrahicalData } from "../../Interfaces/ISaveGrahicalData";

export interface IVisible extends IPositionObject, ISaveGrahicalData {
    getVisibleSize(): number[][]
    setVisibleSize(size: number[][]): void
}