import { ICategoryArrow } from "./ICategoryArrow";
import { ICategoryObject } from "./ICategoryObject";
import { IDesktop } from "./IDesktop";


export class CategoryArrow implements ICategoryArrow
{
    constructor(desktop: IDesktop, name: string) {
        this.desktop = desktop;
        this.name = name;
        desktop.addArrow(this);
    }

    protected name !: string;

    protected desktop !: IDesktop;

    getDesktop(): IDesktop {
        return this.desktop;
    }

    getName(): string {
        return this.name;
    }

    source!: ICategoryObject;

    target!: ICategoryObject;

    getSource(): ICategoryObject {
        return this.source;
    }
    getTagret(): ICategoryObject {
        return this.target;
    }
    setSource(source: ICategoryObject): void {
        this.source = source;
    }
    setTarget(target: ICategoryObject): void {
        this.target = target;
    }
}

class FictiveCategoryArrow implements ICategoryArrow
{
    getSource(): ICategoryObject {
        throw new Error("Method not implemented.");
    }
    getTagret(): ICategoryObject {
        throw new Error("Method not implemented.");
    }
    setSource(source: ICategoryObject): void {
        throw new Error("Method not implemented.");
    }
    setTarget(target: ICategoryObject): void {
        throw new Error("Method not implemented.");
    }
    getName(): string {
        throw new Error("Method not implemented.");
    }
    getDesktop(): IDesktop {
        throw new Error("Method not implemented.");
    }

}