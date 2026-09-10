import type { IFuncT } from "../Interfaces/IFuncT";
import type { ITextReader } from "../IO/Interfaces/ITextReader";
import type { ITextReaderFactory } from "../IO/Interfaces/ITextReaderFactory";
import { LinesTextReaderFromAny } from "../IO/LinesTextReaderFromAny";
import type { IResourceFunc } from "./Infrefaces/IResourceFunc";
import type { IResourceItem } from "./Infrefaces/IResourceItem";

export class TextReaderFromResource implements ITextReaderFactory {

    constructor(items: IResourceItem[], func: IFuncT<IResourceFunc | undefined, 'text' | 'json' | 'image'>)
    {
        const f = func.functT('text');
        if (f === undefined) return
        this.func = f
        for (let r of items) {
            if (r.type == "text") {
                const url = r.url
                const d = f.functT(url)
                this.map.set(url, d)
            }
        }
    }
    getTextReader(obj: any, url: string): ITextReader | undefined {
        this.any = obj
        return this.functT(url)
    }

    functT(url: string): ITextReader | undefined {
        if (!this.map.has(url)) return undefined
        let r = this.map.get(url)
        if (r != undefined) {
            let any = this.func.functT(url)
            return new LinesTextReaderFromAny(any)
        }
        return undefined
    }

    items: IResourceItem[] = []
    func !: IResourceFunc 
    map: Map<string, IResourceItem> = new Map()
    any : any


}

