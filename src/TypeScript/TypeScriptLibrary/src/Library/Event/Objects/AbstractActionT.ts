import { EmptyObject } from "../../EmptyObject"
import type { IActionT } from "../../Interfaces/IActionT"
import type { IFuncT } from "../../Interfaces/IFuncT"
import type { IShowData } from "../../Show/Interfaces/IShowData"

export abstract class AbstractActionT<T> extends EmptyObject implements IActionT<T> {
    constructor(func ?: IFuncT<boolean, IShowData>) {
        super("")
        if (func != undefined) this.func = func
        this.typeName = "AbstractActionT"
        this.types.push("IActionT")
        this.types.push("AbstractActionT")
    }

    protected isProhibited(show: IShowData): boolean {
        if (this.func == undefined) return false
        let b = this.func.functT(show)
        if (b == undefined) return false
        return !b
    }

    abstract actionT(t: T): void 

    isEmptyActionT(): boolean {
        return false
    }

    func !: IFuncT<boolean, IShowData>
}