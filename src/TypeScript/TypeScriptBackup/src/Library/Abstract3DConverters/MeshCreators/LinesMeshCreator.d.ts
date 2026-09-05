import type { IFactory } from "../../Interfaces/IFactory";
import type { ITextReaderFactory } from "../../IO/Interfaces/ITextReaderFactory";
import { AbstractMeshCreator } from "./AbstractMeshCreator";
export declare abstract class LinesMeshCreator extends AbstractMeshCreator {
    constructor(url: string, name: string, directory: string, obj: any, factory: IFactory, func: ITextReaderFactory | undefined);
    loadMeshCreator(): void;
    protected loadStrings(url: string): string[];
    func: ITextReaderFactory;
    protected abstract loadLines(): void;
    getName(): string;
    lines: string[];
    globalString: string;
}
//# sourceMappingURL=LinesMeshCreator.d.ts.map