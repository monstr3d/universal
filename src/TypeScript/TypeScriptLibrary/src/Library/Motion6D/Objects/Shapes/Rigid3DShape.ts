import { CategoryObject } from "../../../CategoryObject"
import type { IDesktop } from "../../../Interfaces/IDesktop"

export class Rigig3DShape extends CategoryObject  {
    constructor(desktop: IDesktop, name: string) {
        super(desktop, name)
        this.typeName = "Rigig3DShape"
        this.types.push("Rigig3DShape")
    }
}