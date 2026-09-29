import { AbstractActionT } from "./AbstractActionT"

export class EmptyActionT<T> extends AbstractActionT<T> {
    constructor() {
        super()
        this.typeName = "EmptyActionT"
        this.types.push("EmptyActionT")
    }

    actionT(t: T): void {
        this.t = t
    }

    isEmptyActionT(): boolean {
        return true
    }

    t !: T
}