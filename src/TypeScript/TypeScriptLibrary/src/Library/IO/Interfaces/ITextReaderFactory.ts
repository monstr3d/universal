import type { ITextReader } from "./ITextReader";

export interface ITextReaderFactory {
    getTextReader(obj: any, url: string): ITextReader | undefined
}