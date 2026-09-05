import type { IComparator } from "../../Utilities/Sort/Interfaces/IComparator";
import type { IPosition } from "../Interfaces/IPosition";

export class PositionComparer implements IComparator<IPosition> {
    compare(x: IPosition, y: IPosition): number {
        if (this.isSource(x, y)) return -1;
        if (this.isSource(y, x)) return 1;
        return 0;

    }
    isSource(source: IPosition, target: IPosition) {
        var tp = target.getParentFrame()
        if (tp === undefined) {
            return false;
        }
        if (tp == source) {
            return true;
        }
        if (this.isSource(source, tp)) {
            return true;
        }
        return false;
    }
}