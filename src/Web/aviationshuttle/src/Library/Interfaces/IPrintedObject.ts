import type { IPrinter } from "./IPrinter";

export interface IPrintedObject {
    print(printer: IPrinter) : void
}