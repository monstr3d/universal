import { ICategoryArrow } from "./ICategoryArrow";
import { ICategoryObject } from "./ICategoryObject";
import { IDesktop } from "./IDesktop";
import { IObject } from "./IObject";
import { Check } from "./Types/Check";

export class Desktop implements IDesktop
{
    addObject(obj: IObject): void {
        this.objects.push(obj);
    }
    getObjects(): IObject[] {
        return this.objects;
    }
    setCheck(check: Check): void {
        this.check = check
    }
    getCheck() {
        return  this.check;
    }

    protected check: Check = () => {
        return true;
    }

    protected categoryObjects: ICategoryObject[] = [];

    protected categoryArrows: ICategoryArrow[] = [];

    protected objects: IObject[] = [];

    protected name!: string;

    protected arrow!: ICategoryArrow;


    protected source!: ICategoryObject;


    protected target!: ICategoryObject;

    getCategoryObjects(): ICategoryObject[] {
        return this.categoryObjects;
    }
    getCategoryArrows(): ICategoryArrow[] {
        return this.categoryArrows;
    }
    addCategoryObject(obj: ICategoryObject): void {
        this.categoryObjects.push(obj);
    }
    addCategoryArrow(arr: ICategoryArrow): void {
        this.categoryArrows.push(arr);
    }
    getName(): string {
        return this.name;
    }

}