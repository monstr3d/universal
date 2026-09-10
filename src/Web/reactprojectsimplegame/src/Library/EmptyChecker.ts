import { EmptyObject } from "./EmptyObject";
import type { ICheck } from "./Interfaces/ICheck";

export class EmptyChecker extends EmptyObject implements ICheck {
    constructor() {
        super("")
        this.types.push("ICheck")
        this.types.push("EmptyChecker")
        this.typeName = "EmptyChecker"
    }
    check(o: any): boolean {
        return o == undefined
    }

}