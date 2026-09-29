import { EmptyObject } from "../EmptyObject";
import type { ITextReader } from "./Interfaces/ITextReader";


export class LinesTextReader extends EmptyObject implements ITextReader {

    constructor() {
        super("")
        this.types.push("ITextReader")
        this.types.push("EmptyObject")
        this.typeName = "EmptyObject"
    }

    getStrings(): string[] {
        return this.strings
    }

    reset(): void {
        this.n = 0;
        this.end = false
    }

    readToEnd(): string {
        this.end = true;
        return this.text;
    }

    readLine(): string {
        let s = this.strings[this.n];
        this.n++;
        if (this.n >= this.strings.length) this.end = true;
        return s;
    }

    eof(): boolean {
        return this.end;
    }

    protected split(): void {
        var s = this.text.split("\n")
        for (var str of s) {
            this.strings.push(str.replace("\r", ""))
        }
    }


    protected typeName: string = "LinesTextReader";

    protected types: string[] = ["IObject", "ITextReader", "LinesTextReader"];

    protected name: string = "";


    strings: string[] = [];

    text: string = "";

    end: boolean = false;

    n = 0;

}
