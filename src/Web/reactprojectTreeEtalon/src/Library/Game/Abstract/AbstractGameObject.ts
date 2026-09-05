import type { IFactory } from "../../Interfaces/IFactory";
import type { IFactoryConsumer } from "../../Interfaces/IFactoryConsumer";
import type { IObject } from "../../Interfaces/IObject";
import type { IShowObject } from "../../Show/Interfaces/IShowObject";
import { GamePerformer } from "../GamePerformer";

export class AbstractGameObject implements IObject, IFactoryConsumer {
    protected performer: GamePerformer = new GamePerformer()
    constructor(name: string, factory: IFactory | undefined) {
        this.name = name
        this.setFactory(factory)
    }
    setConsumerFactory(factory: IFactory): void {
        this.setFactory(factory)
    }
    getConsumerFactory(): IFactory {
        return this.factory
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

    protected setFactory(factory: IFactory | undefined) {
        if (factory == null) return
        this.factory = factory
        this.detectShow()
    }


    protected detectShow(): void {
        if (this.showObj != undefined) return
        const sh = this.factory.getFactory<IShowObject>("IShowObject")
        if (sh != undefined) this.showObj = sh
    }

    public showObject(sender: any, object: any, name?: string | undefined): void {
        if (this.showObj == undefined) return
        this.showObj.show(sender, object, name)
    }


    protected typeName: string = "AbstactGameObject"

    protected types: string[] = ["IObject", "IFactoryConsumer", "AbstactGameObject"]

    protected name: string = ""

    protected factory !: IFactory

    protected showObj !: IShowObject

}
