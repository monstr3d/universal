import { LinesTextReader } from "./LinesTextReader";

export class LinesTextReaderFromAny extends LinesTextReader {
    constructor(any: any) {
        super()
        let str = any as unknown as string
        if (str != undefined) {
            this.text = str.replaceAll("\r\n", "\n")
            this.split()
            return
        }

        let strs = any as unknown as string[]
        if (strs.length == 1) {
            this.text = strs[0]
            this.split()
            return
        }
        if (strs != undefined) {
            this.strings = strs
            return;
        }
    }
}