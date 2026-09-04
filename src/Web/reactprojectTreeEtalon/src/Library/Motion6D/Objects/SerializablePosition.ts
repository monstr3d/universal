import type { ICategoryObject } from "../../Interfaces/ICategoryObject";
import type { IDesktop } from "../../Interfaces/IDesktop";
import type { IPostSetArrow } from "../../Interfaces/IPostSetArrow";
import type { IChildrenT } from "../../NamedTree/Interfaces/IChildrenT";
import type { IPositionObject } from "../Interfaces/IPositionObject";
import { BasicPosition } from "./BasicPosition";

export class SerializablePosition extends BasicPosition
    implements IChildrenT<ICategoryObject>, IPostSetArrow {

    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);
        this.typeName = "SerializablePosition";
        this.types.push("SerializablePosition");
    }
    postSetArrow(): void {
        if (this.objects.length == 1) {
            this.setParameters(this.objects[0])
        }
    }
    getChildernT(): ICategoryObject[] {
        return this.objects
    }
    addChildT(child: ICategoryObject): void {
        this.objects.push(child)
    }
    removeChildT(child: ICategoryObject): void {
        this.performer.remove(this.objects, child)
    }

    setParameters(parameters: any): void {
        super.setParameters(parameters)
        var po = this.performer.convertObject<IPositionObject, any>(parameters, "IPositionObject")
        if (po.length == 0) return;
        po[0].setObjectPosition(this)
    }

    objects: ICategoryObject[] = [];

    protected map: Map<string, string> = new Map();

}