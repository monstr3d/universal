/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { ICategoryObject } from "./Interfaces/ICategoryObject";
import type { ICheck } from "./Interfaces/ICheck";
import type { IDesktop } from "./Interfaces/IDesktop";
import type { IFactory } from "./Interfaces/IFactory";
import type { IFactoryConsumer } from "./Interfaces/IFactoryConsumer";
import type { IObject } from "./Interfaces/IObject";
import { Performer } from "./Performer";

export class CategoryObject implements ICategoryObject, IObject
{
    protected desktop !: IDesktop;

    protected obj !: Object;

    protected name !: string;

    protected checker !: ICheck;

    protected variable !: any;

    protected types: string[] = ["IObject", "ICategoryObject", "CategoryObject"];

    protected typeName: string = "CategoryObject";

    protected performer: Performer = new Performer();

    protected fic !: any

    constructor(desktop: IDesktop, name: string) {
        this.desktop = desktop;
        this.name = name;
        desktop.addCategoryObject(this);
        desktop.addObject(this);
        this.checker = desktop.getCheck();
    }


    getName(): string {
        return this.name;
    }

    getClassName(): string {
        return this.typeName;
    }

    imlplementsType(type: string): boolean {
        return this.types.includes(type);
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

    getCategoryObjectName(): string {
        return this.name;
    }

    protected check(x: any): boolean {
        if (this.checker == undefined) {
            return false;
        }
        return this.checker.check(x);
    }


    protected getObjectT<T, S>(s: S, type: string): T[] {
        return this.performer.convertObject<T, S>(s, type)
    }

    public detectFactory(): IFactory | undefined {
        let fc = this.desktop as unknown as IFactoryConsumer
        if (fc === undefined) return undefined
        return fc.getConsumerFactory()
    }

}

