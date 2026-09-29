import { FactoryObject } from "../FactoryObject"
import type { IFactory } from "../Interfaces/IFactory"
import type { IResourceFunc } from "./Infrefaces/IResourceFunc"
import type { IResourceFuncFactory } from "./Infrefaces/IResourceFuncFactory"

export class ResourceFuncFactory extends FactoryObject implements IResourceFuncFactory {

    constructor(name: string, factory: IFactory | undefined) {
        super(name, factory)
        this.types.push("IResourceFuncFactory")
        this.types.push("ResourceFuncFactory")
        this.typeName = "ResourceFuncFactory"
    }

    public addFunction(type: 'text' | 'json' | 'image', func: IResourceFunc): boolean {
        if (this.map.has(type)) return false
        this.map.set(type, func)
        return true
    }

    functT(s: 'text' | 'json' | 'image'): IResourceFunc | undefined {
        if (this.map.has(s)) return this.map.get(s)
        return undefined
    }

    map: Map<'text' | 'json' | 'image', IResourceFunc> = new Map()
}