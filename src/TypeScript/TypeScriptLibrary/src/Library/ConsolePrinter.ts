import type { IPrinter } from "./Interfaces/IPrinter";

export class ConsolePrinter implements IPrinter {
    print(obj: any): void {
        console.log(obj);
    }

}
