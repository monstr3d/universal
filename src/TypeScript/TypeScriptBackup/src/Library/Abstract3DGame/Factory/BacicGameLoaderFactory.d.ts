import { AbstractGameLoaderFactory } from "../../Game/Abstract/AbstractGameLoaderFactory";
import type { ILoader } from "../../Interfaces/ILoader";
export declare class BasicGameLoaderFactory extends AbstractGameLoaderFactory {
    constructor();
    getLoader(object: any): ILoader;
    current: any;
}
//# sourceMappingURL=BacicGameLoaderFactory.d.ts.map