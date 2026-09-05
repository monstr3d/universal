import type { ReferenceFrame } from "../ReferenceFrame";
import type { IPosition } from "./IPosition";

export interface IReferenceFrame extends IPosition {

    getOwnFrame(): ReferenceFrame | undefined;
}