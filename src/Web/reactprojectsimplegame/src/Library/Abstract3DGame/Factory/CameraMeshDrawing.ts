import { EmptyObject } from "../../EmptyObject";
import type { IGameActionConverter } from "../../Game/Interfaces/IGameActionConverter";
import { BasicCamera } from "../../Motion6D/Visible/BasicCamera";
import type { ICameraMeshDrawing } from "../Interfaces/ICameraMeshDrawing";

export class CameraMeshDrawing extends EmptyObject implements ICameraMeshDrawing {

    constructor() {
        super("")
    }

    functT(s: BasicCamera): IGameActionConverter | undefined {
        this.any = s
        return undefined
    }

    any : any
}