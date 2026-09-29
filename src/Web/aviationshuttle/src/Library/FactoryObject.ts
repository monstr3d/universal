import { EmptyObject } from "./EmptyObject";
import type { IFactory } from "./Interfaces/IFactory";
import type { IFactoryConsumer } from "./Interfaces/IFactoryConsumer";
import type { IShowObject } from "./Show/Interfaces/IShowObject";

export class FactoryObject extends EmptyObject implements IFactoryConsumer {
    constructor(name: string, factory: IFactory | undefined) {
        super(name)
        this.types.push("IFactoryConsumer")
        this.types.push("FactoryObject")
        this.typeName = "FactoryObject"
        this.setFactory(factory)
    }

    setConsumerFactory(factory: IFactory): void {
        this.setFactory(factory)
    }
    getConsumerFactory(): IFactory {
        return this.factory
    }

    protected detectShow(): void {
        if (this.showObj != undefined) return
        const sh = this.factory.getFactory<IShowObject>("IShowObject")
        if (sh != undefined) this.showObj = sh
    }

    public showObject(sender : any, object: any, name?: string | undefined): void {
        if (this.showObj == undefined) return
        this.showObj.show(sender, object, name)
    }

    protected setFactory(factory: IFactory | undefined) {
        if (factory == null) return
        this.factory = factory
        this.detectShow()
    }


    protected factory !: IFactory

    protected showObj !: IShowObject

    

}