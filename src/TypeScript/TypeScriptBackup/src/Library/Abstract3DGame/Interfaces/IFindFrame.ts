import type { IScene } from "../../Game/Interfaces/IScene";
import type { IFuncT } from "../../Interfaces/IFuncT";
import type { IReferenceFrame } from "../../Motion6D/Interfaces/IReferenceFrame";

export interface IFindFrame extends IFuncT<IReferenceFrame, IScene> { }