import type { IObject } from "../../Interfaces/IObject";
import type { ITextReaderFactory } from "../../IO/Interfaces/ITextReaderFactory";
import type { IMtlDetector } from "../Interfaces/IMtlDetector";
export declare class MtlDetectorTextReader implements IObject, IMtlDetector {
    factory: ITextReaderFactory;
    constructor(factory: ITextReaderFactory);
    detectMtl(url: string, obj: any): string[];
    getName(): string;
    getClassName(): string;
    imlplementsType(type: string): boolean;
    protected typeName: string;
    protected types: string[];
    protected name: string;
}
//# sourceMappingURL=MtlDetectorTextReader.d.ts.map