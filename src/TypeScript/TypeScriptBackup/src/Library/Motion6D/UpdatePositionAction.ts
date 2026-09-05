import type { IAction } from "../Interfaces/IAction";
import type { IPosition } from "./Interfaces/IPosition";

export class UpdatePositionAction implements IAction
{
    position: IPosition;

    constructor(position: IPosition) {
        this.position = position;
    }
    action(): void {
        this.position.updateReferenceFrame()
    }
    isEmptyAction(): boolean { return false }

}