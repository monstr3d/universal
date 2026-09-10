import { AbstractAction } from "./AbstractAction";

export class EmptyAction extends AbstractAction {
    constructor() {
        super()
        this.typeName = "EmptyAction"
        this.types.push("EmptyAction")
    }

    action(): void {
    }

    isEmptyAction(): boolean {
        return true
    }
}