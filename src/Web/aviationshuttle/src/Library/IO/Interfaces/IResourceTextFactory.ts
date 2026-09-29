import type { IResourceFuncFactory } from "../../Resources/Infrefaces/IResourceFuncFactory";
import type { ITextReaderFactory } from "./ITextReaderFactory";

export interface IResourceTextFactory { text: ITextReaderFactory, resource : IResourceFuncFactory }