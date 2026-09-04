/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

import { CategoryArrow } from "../../CategoryArrow";
import type { ICategoryObject } from "../../Interfaces/ICategoryObject";
import type { IDesktop } from "../../Interfaces/IDesktop";
import type { IObjectTransformer } from "../Interfaces/IObjectTransformer";
import type { IObjectTransformerConsumer } from "../Interfaces/IObjectTransformerConsumer";


export class ObjectTransformerLink extends CategoryArrow
{
    constructor(desktop: IDesktop, name: string) {
        super(desktop, name)
        this.typeName = "ObjectTransformerLink";
        this.types.push("ObjectTransformerLink");
    }
    getSource(): ICategoryObject {
        return this.consumer as unknown as ICategoryObject;
    }

    getTagret(): ICategoryObject {
        return this.transformer as unknown as ICategoryObject;
    }

    setSource(source: ICategoryObject): void {
        this.consumer = source as unknown as IObjectTransformerConsumer;
    }

    setTarget(target: ICategoryObject): void {
        this.transformer = target as unknown as IObjectTransformer;
        this.consumer.addTransformer(this.transformer);
    }

    getName(): string {
        return this.name;
    }


    consumer !: IObjectTransformerConsumer;

    transformer !: IObjectTransformer;


}
