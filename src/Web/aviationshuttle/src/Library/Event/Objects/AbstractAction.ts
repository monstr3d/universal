import { EmptyObject } from "../../EmptyObject"
import type { IAction } from "../../Interfaces/IAction"

export abstract class AbstractAction extends EmptyObject implements IAction {
    constructor() {
        super("")
        this.typeName = "AbstractAction"
        this.types.push("IAction")
        this.types.push("AbstractAction")
    }

    abstract action(): void 

    isEmptyAction(): boolean {
        return false
    }
}
