import { EmptyObject } from "../../EmptyObject";
import { GamePerformer } from "../../Game/GamePerformer";
import type { IScene } from "../../Game/Interfaces/IScene";
import type { IReferenceFrame } from "../../Motion6D/Interfaces/IReferenceFrame";
import type { IFindFrame } from "../Interfaces/IFindFrame";
export declare abstract class AbstractFindFrame extends EmptyObject implements IFindFrame {
    abstract functT(s: IScene): IReferenceFrame | undefined;
    protected performer: GamePerformer;
    constructor(name: string);
}
//# sourceMappingURL=AbstractFindFrame.d.ts.map