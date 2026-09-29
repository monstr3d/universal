import type { IFactory } from "./Interfaces/IFactory";
import type { IObject } from "./Interfaces/IObject";
import { OwnError } from "./ErrorHandler/OwnError";
import { FactoryObject } from "./FactoryObject";

export class UniversalFactory extends FactoryObject implements IFactory {
    constructor() {
        super("", undefined)
        this.factory = this;
        this.types.push("IFactory")
        this.types.push("UniversalFactory")
        this.typeName = "UniversalFactory"
    }

    removeFactory<T>(t: T, type: string): void {
        let x = this.factories.get(type)
        if (x != t) throw new OwnError("Illegal delete factory", "", "")
        this.factories.delete(type)
    }
    
    getFactory<T>(typeName: string): T | undefined {
        var p = this.factories.get(typeName)
        var pp = this.performer.convertObject<T, any>(p, typeName)
        return (pp.length == 0) ? undefined : pp[0]
    }

    addFactory<T>(t: T, type: string): void {
   if (this.factories.has(type)) throw new OwnError("Factory", type, "aleady exists")
        var tt = this.performer.convertObject<IObject, T>(t, type)
        if (tt.length > 0) this.factories.set(type, tt[0])
        else
            console.log("FAIL ", type)
    }


    protected factories: Map<string, IObject> = new Map();
}