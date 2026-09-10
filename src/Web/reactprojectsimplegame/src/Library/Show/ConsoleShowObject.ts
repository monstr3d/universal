import { AbstractActionT } from "../Event/Objects/AbstractActionT";
import type { IFuncT } from "../Interfaces/IFuncT";
import type { IShowData } from "./Interfaces/IShowData";

export class ConsoleShowObject extends AbstractActionT<IShowData> {
    constructor(func?: IFuncT<boolean, IShowData>) {
        super(func)
    }

    actionT(t: IShowData): void {
        if (this.isProhibited(t)) return
        ++this.i
        console.log("\n")
        console.log("Name ", t.name)
        console.log("Object ", t.show)
        console.log("Sender ", t.sender)
        console.log("Number ", this.i)
        console.log("\n")
 }

    i: number = 0
}