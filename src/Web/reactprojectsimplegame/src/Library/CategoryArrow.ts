
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { EmptyObject } from "./EmptyObject";
import type { ICategoryArrow } from "./Interfaces/ICategoryArrow";
import type { ICategoryObject } from "./Interfaces/ICategoryObject";
import type { IDesktop } from "./Interfaces/IDesktop";
import { Performer } from "./Performer";

export class CategoryArrow extends EmptyObject implements ICategoryArrow
{
    constructor(desktop: IDesktop, name: string) {
        super(name)
        this.typeName = "CategoryArrow"
        this.types.push("ICategoryArrow")
        this.types.push("CategoryArrow")
        this.desktop = desktop;
        this.name = name;
        desktop.addCategoryArrow(this);
        desktop.addObject(this);
    }
 
    protected desktop: IDesktop

    protected source !: ICategoryObject


    protected target !: ICategoryObject


    protected performer: Performer = new Performer()

   getDesktop(): IDesktop {
        return this.desktop;
    }


    getArrowName(): string {
        return this.name;
    }


    getSource(): ICategoryObject {
        return this.source;
    }

    getTarget(): ICategoryObject {
        return this.target;
    }

    setSource(source: ICategoryObject): void {
        this.source = source;
    }

    setTarget(target: ICategoryObject): void {
        this.target = target;
    }

    protected getObjectT<T, S>(s : S, type: string) : T[]
    {
        return this.performer.convertObject<T, S>(s, type)
    }
}

