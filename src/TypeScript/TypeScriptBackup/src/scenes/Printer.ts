import { IPrinter } from "../Library/Interfaces/IPrinter";

export class Printer implements IPrinter {
    print(obj: any): void {
        console.log(obj)
    }

}