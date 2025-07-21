import { ICategoryObject } from "./ICategoryObject";
import { IDesktop } from "./IDesktop";
import { Performer } from "./Performer";
import { Check } from "./Types/Check";

export class CategoryObject implements ICategoryObject
{
    protected desktop !: IDesktop;

    protected obj !: Object;

    protected name !: string;

    protected checker !: Check;

    protected variable !: any;

    protected performer: Performer = new Performer();

    constructor(desktop: IDesktop, name: string) {
        this.desktop = desktop;
        this.name = name;
        desktop.addObject(this);
        this.checker = desktop.getCheck();
    }

    protected convert<T>(a: any): T {
        return this.performer.convertFromAny<T>(a);
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

    protected check(x: any): boolean {
        return this.checker(x);
    }
}

