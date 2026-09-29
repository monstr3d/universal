import { EmptyObject } from "../EmptyObject";
import type { IPrinter } from "../Interfaces/IPrinter";

export class ConsoleStringPrinter extends EmptyObject implements IPrinter {
    constructor() {
        super("")
        this.types.push("IPrinter")
        this.types.push("ConsoleStringPrinter")
        this.typeName = "ConsoleStringPrinter"
    }
    print(obj: any): void {
        console.log(obj + "");
    }

}
