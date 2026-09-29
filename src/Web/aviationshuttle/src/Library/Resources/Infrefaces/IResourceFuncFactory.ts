import type { IFuncT } from "../../Interfaces/IFuncT";
import type { IResourceFunc } from "./IResourceFunc";

export interface IResourceFuncFactory extends IFuncT<IResourceFunc | undefined, 'text' | 'json' | 'image'> {

}