import type { IFuncT } from "../Interfaces/IFuncT";
import type { ITextReader } from "./Interfaces/ITextReader";
import type { ITextReaderFactory } from "./Interfaces/ITextReaderFactory";

export class ConverterTextReadertFactory implements ITextReaderFactory {
    constructor(factory: ITextReaderFactory, func: IFuncT<string, string>) {
        this.factory = factory
        this.func = func
    }

    getTextReader(obj: any, url: string): ITextReader | undefined {
        let str = this.func.functT(url)
        if (str == undefined) return undefined
        return this.factory.getTextReader(obj, str)
    }

    factory !: ITextReaderFactory
    func !: IFuncT<string, string>
    any : any

}