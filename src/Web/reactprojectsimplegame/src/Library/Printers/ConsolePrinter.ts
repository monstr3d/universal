import { EmptyObject } from "../EmptyObject";
import type { IPrinter } from "../Interfaces/IPrinter";

export class ConsolePrinter extends EmptyObject implements IPrinter {
    constructor() {
        super("")
        this.types.push("IPrinter")
        this.types.push("ConsolePrinter")
        this.typeName = "ConsolePrinter"
    }
    print(obj: any): void {
        console.log(obj);
    }

}
