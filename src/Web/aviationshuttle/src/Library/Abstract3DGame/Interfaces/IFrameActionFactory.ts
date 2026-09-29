import type { IFuncT } from "../../Interfaces/IFuncT";
import type { IReferenceFrame } from "../../Motion6D/Interfaces/IReferenceFrame";
import type { IFrameAction } from "./IFrameAction";

export interface IFrameActionFactoty extends IFuncT<IFrameAction, IReferenceFrame> {

}