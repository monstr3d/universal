import { ICategoryObject } from "./ICategoryObject";
import { IDesktop } from "./IDesktop";

export class CategoryObject implements ICategoryObject
{
    protected desktop !: IDesktop;

    protected obj !: Object;

    protected name !: string;

    constructor(desktop: IDesktop, name: string) {
        this.desktop = desktop;
        this.name = name;
        desktop.addObject(this);
    }

    getDesktop(): IDesktop {
        return this.desktop;
    }

    getObject(): Object {
        return this.obj;
    }
    setObject(obj: Object): void {
        this.obj = obj;
    }
    getName(): string {
        return this.name;
    }
}

class FictiveCategoryObject implements ICategoryObject
{
    getObject(): Object {
        throw new Error("Method not implemented.");
    }
    setObject(obj: Object): void {
        throw new Error("Method not implemented.");
    }
    getName(): string {
        throw new Error("Method not implemented.");
    }
    getDesktop(): IDesktop {
        throw new Error("Method not implemented.");
    }

}