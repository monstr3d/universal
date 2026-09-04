import { CategoryArrow } from "../CategoryArrow";
import { OwnError } from "../ErrorHandler/OwnError";
import type { IAddRemove } from "../Interfaces/IAddRemove";
import type { ICategoryObject } from "../Interfaces/ICategoryObject";
import type { IDesktop } from "../Interfaces/IDesktop";

export class BelongsToCollection extends CategoryArrow
{
    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);
        this.typeName = "BelongsToCollection"
        this.types.push("BelongsToCollection")
     }


    setSource(source: ICategoryObject): void {
        this.source = source;
        let a = this.getObjectT<IAddRemove, ICategoryObject>(source, "IAddRemove")
        if (a.length == 0) {
            throw new OwnError("BelongsToCollection", "setSource", "")
        }
        this.ar = a[0]
    }

    setTarget(target: ICategoryObject): void {
        this.target = target;
        this.ar.addRemoveObject(target, true)
    }

    protected ar !: IAddRemove

}