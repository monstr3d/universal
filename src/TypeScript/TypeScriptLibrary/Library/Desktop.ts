import { ICategoryArrow } from "./ICategoryArrow";
import { ICategoryObject } from "./ICategoryObject";
import { IDesktop } from "./IDesktop";

export class Desktop implements IDesktop
{

    protected objects: ICategoryObject[] = [];

    protected arrows: ICategoryArrow[] = [];

    protected name!: string;

    protected arrow!: ICategoryArrow;


    protected source!: ICategoryObject;


    protected target!: ICategoryObject;



    getObjects(): ICategoryObject[] {
        return this.objects;
    }
    getArrows(): ICategoryArrow[] {
        return this.arrows;
    }
    addObject(obj: ICategoryObject): void {
        this.objects.push(obj);
    }
    addArrow(arr: ICategoryArrow): void {
        this.arrows.push(arr);
    }
    getName(): string {
        return this.name;
    }

}