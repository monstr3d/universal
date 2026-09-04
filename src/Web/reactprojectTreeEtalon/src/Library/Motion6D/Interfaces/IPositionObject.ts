import type { IPosition } from "./IPosition";

export interface IPositionObject {
    getObjectPosition(): IPosition;
    setObjectPosition(position: IPosition): void
}