import { ICategoryObject } from "./Interfaces/ICategoryObject";
import { IDesktop } from "./Interfaces/IDesktop";
import { IObject } from "./Interfaces/IObject";
import { Performer } from "./Performer";
import { Check } from "./Types/Check";

export class CategoryObject implements ICategoryObject, IObject
{
    protected desktop !: IDesktop;

    protected obj !: Object;

    protected name !: string;

    protected checker !: Check;

    protected variable !: any;

    protected types: string[] = ["ICategoryObject", "CategoryObject"];

    protected typeName: string = "CategoryObject";

    protected performer: Performer = new Performer();

    constructor(desktop: IDesktop, name: string) {
        this.desktop = desktop;
        this.name = name;
        desktop.addCategoryObject(this);
        desktop.addObject(this);
        this.checker = desktop.getCheck();
        this.types.push("IObject");
        this.types.push("ICategoryObject");
        this.types.push("CategoryObject");
    }

    getClassName(): string {
        return this.typeName;
    }
    imlplementsType(type: string): boolean {
        return this.types.indexOf(type) > 0;
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

