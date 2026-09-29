import { CategoryArrow } from "../../CategoryArrow";
import type { ICategoryObject } from "../../Interfaces/ICategoryObject";
import type { IDesktop } from "../../Interfaces/IDesktop";
import type { IVisible } from "./Interfaces/IVisible";
import type { IVisibleConsumer } from "./Interfaces/IVisibleConsumer";

export class VisibleConsumerLink extends CategoryArrow {
    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);
        this.typeName = "VisibleConsumerLink";
        this.types.push("VisibleConsumerLink");
    }

    getSource(): ICategoryObject {
        return this.consumer as unknown as ICategoryObject;
    }

    getTagret(): ICategoryObject {
        return this.visible as unknown as ICategoryObject;
    }

    setSource(source: ICategoryObject): void {
        var c = this.performer.convertProperties<IVisibleConsumer>(source, "IVisibleConsumer")
        this.consumer = c[0]
    }

    setTarget(target: ICategoryObject): void {
        this.visible = this.performer.convertProperties<IVisible>(target, "IVisible")[0]
        this.consumer.addVisibleObject(this.visible)
       }

    consumer!: IVisibleConsumer;

    visible!: IVisible;

}