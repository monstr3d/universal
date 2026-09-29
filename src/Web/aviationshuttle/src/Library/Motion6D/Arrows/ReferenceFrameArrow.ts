import { CategoryArrow } from "../../CategoryArrow";
import type { ICategoryObject } from "../../Interfaces/ICategoryObject";
import type { IDesktop } from "../../Interfaces/IDesktop";
import type { INodeT } from "../../NamedTree/Interfaces/INodeT";
import type { IPosition } from "../Interfaces/IPosition";
import type { IReferenceFrame } from "../Interfaces/IReferenceFrame";


export class ReferenceFrameArrow extends CategoryArrow {
    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);
        this.typeName = "ReferenceFrameArrow";
        this.types.push("ReferenceFrameArrow");
    }

    getSource(): ICategoryObject {
        return this.position as unknown as ICategoryObject;
    }

    getTagret(): ICategoryObject {
        return this.frame as unknown as ICategoryObject;
    }

    setSource(source: ICategoryObject): void {
        this.position = source as unknown as IPosition;
        this.positionNode = this.position;
    }

    setTarget(target: ICategoryObject): void {
        let f = target as unknown as IReferenceFrame;
        this.frame = f;
        let p = f as unknown as INodeT<IPosition>;
        if (p === undefined) { } else {

            p.addNodeT(this.positionNode);
        }
        this.position.setParentFrame(f)
    }



    position!: IPosition;

    positionNode!: INodeT<IPosition>;

    frame!: IReferenceFrame;
}
