/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

import { OwnNotImplemented } from "./ErrorHandler/OwnNotImplemented";
import { Performer } from "./Performer";
import type { ICategoryArrow } from "./Interfaces/ICategoryArrow";
import type { ICategoryObject } from "./Interfaces/ICategoryObject";
import type { ICheck } from "./Interfaces/ICheck";
import type { IDesktop } from "./Interfaces/IDesktop";
import type { IObject } from "./Interfaces/IObject";
import type { IInitializeTask } from "./Interfaces/IInitializeTask"
import type { IFactory } from "./Interfaces/IFactory";
import type { IFactoryConsumer } from "./Interfaces/IFactoryConsumer";

export class Desktop implements IDesktop, IObject, IFactoryConsumer
{

    protected factory !: IFactory

    protected typeName: string = "Desktop";

    protected types: string[] = ["IObject", "IDesktop"
        , "IComponentCollection", "IObjectCollection", "Desktop", "IFactoryConsumer"];

    protected categoryObjects: ICategoryObject[] = [];

    protected categoryArrows: ICategoryArrow[] = [];

    protected objects: IObject[] = [];

    protected name!: string;

    protected arrow!: ICategoryArrow;

    protected source!: ICategoryObject;


    protected target!: ICategoryObject;

    protected check !: ICheck;

    protected mapObjects: Map<string, ICategoryObject> = new Map()


    protected performer: Performer = new Performer();

    constructor(factory?: IFactory) {
        if (factory === undefined) return
        this.factory = factory
        let c = factory.getFactory<ICheck>("ICheck")
        if (c !== undefined) this.check = c
    }

    imlplementsType(type: string): boolean {
        return this.types.includes(type);
    }


     async initializeTaksAsync(cancel: AbortController): Promise<void> {
        var init = [];
        var ii = this.performer.getByInterface(this, "IInitializeTask");
        for (var i of ii) {
            var k = i as unknown as IInitializeTask;
            let m = k.initializeTaskAsync(cancel);
            init.push(m);
         }
         await Promise.any(init);
    }

    public async loadAsync(cancel: AbortController): Promise<void> {
        await this.initializeTaksAsync(cancel);
        this.finish();
    }

    public finish(): void {
    }

    getObjectCollection(): IObject[] {
        return this.objects
    }


     addObject(obj: IObject): void {
        this.objects.push(obj);
    }
    getObjects(): IObject[] {
        return this.objects;
    }
    setCheck(check: ICheck): void {
        this.check = check
    }
    getCheck() {
        return this.check;
    }

    setConsumerFactory(factory: IFactory): void {
        this.factory = factory
    }
    getConsumerFactory(): IFactory {
        return this.factory;
    }
    getClassName(): string {
        return this.typeName;
    }


    getCategoryObject(name: string): ICategoryObject {
        for (var o of this.categoryObjects) {
            var n = o.getCategoryObjectName();
            if (n == name) {
                return o;
            }
        }
        throw new OwnNotImplemented("DESKTOP");
    }

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