import type { IScene } from "../../Game/Interfaces/IScene"
import type { IAssociatedObject } from "../../Interfaces/IAssociatedObject"
import type { IObject } from "../../Interfaces/IObject"
import type { IShowObject } from "../../Show/Interfaces/IShowObject"
import type { IResourceFuncFactory } from "../../Resources/Infrefaces/IResourceFuncFactory"
import { AbstractSceneObject } from "./AbstractSceneObject"
import { TextReaderFromResource } from "../../Resources/TextReaderFromResource"
import type { ITextReaderFactory } from "../../IO/Interfaces/ITextReaderFactory"
import type { IResourceItem } from "../../Resources/Infrefaces/IResourceItem"

export abstract class AssociatedSceneObject extends AbstractSceneObject implements IAssociatedObject {

    protected object !: IObject
    constructor(scene: IScene, object: IObject) {
        super(scene, object.getName())
        this.types.push("IAssociatedObject")
        this.types.push("AbstractSceneObject")
        this.typeName = "AbstractSceneObject"
        this.object = object
        this.factory = scene.getConsumerFactory()
        this.show = this.factory.getFactory<IShowObject>("IShowObject")
        this.resourceFactory = this.factory.getFactory<IResourceFuncFactory>("IResourceFuncFactory")

    }
    
    protected getTextFactory(f: ITextReaderFactory | undefined, items: IResourceItem[]): ITextReaderFactory | undefined {
        if (f != undefined) return f
        const ff = this.factory.getFactory<ITextReaderFactory>("ITextReaderFactory")
        if (ff != undefined) return ff;
        if (this.resourceFactory != undefined) {
            const tt = new TextReaderFromResource(items, this.resourceFactory)
            return tt;
        }
    }
    

    protected showObject(object: any, str?: string | undefined): void {
        if (this.show != undefined) this.show.show(object, str)
    }

    getAssociatedObject(): IObject {
        return this.object
    }

    setAssociatedObject(obj: IObject): void {
        this.object = obj
    }


    show: IShowObject | undefined = undefined


    protected resourceFactory: IResourceFuncFactory | undefined = undefined



}