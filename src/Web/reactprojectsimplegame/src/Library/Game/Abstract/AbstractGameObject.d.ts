import type { IFactory } from "../../Interfaces/IFactory";
import type { IFactoryConsumer } from "../../Interfaces/IFactoryConsumer";
import type { IObject } from "../../Interfaces/IObject";
import type { IShowObject } from "../../Show/Interfaces/IShowObject";
import { GamePerformer } from "../GamePerformer";
export declare class AbstractGameObject implements IObject, IFactoryConsumer {
    protected performer: GamePerformer;
    constructor(name: string, factory: IFactory | undefined);
    setConsumerFactory(factory: IFactory): void;
    getConsumerFactory(): IFactory;
    getName(): string;
    getClassName(): string;
    imlplementsType(type: string): boolean;
    protected setFactory(factory: IFactory | undefined): void;
    protected detectShow(): void;
    showObject(sender: any, object: any, name?: string | undefined): void;
    protected typeName: string;
    protected types: string[];
    protected name: string;
    protected factory: IFactory;
    protected showObj: IShowObject;
}
//# sourceMappingURL=AbstractGameObject.d.ts.map