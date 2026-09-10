import type { IScene } from "../../Game/Interfaces/IScene";
import type { ISceneObject } from "../../Game/Interfaces/ISceneObject";
import type { IFactory } from "../../Interfaces/IFactory";
export declare abstract class AbstractSceneObject implements ISceneObject {
    constructor(scene: IScene, name: string);
    abstract setScene(scene: IScene): void;
    setConsumerFactory(factory: IFactory): void;
    getConsumerFactory(): IFactory;
    protected factory: IFactory;
    protected scene: IScene;
    protected typeName: string;
    protected types: string[];
    protected name: string;
    getScene(): IScene;
    getName(): string;
    getClassName(): string;
    imlplementsType(type: string): boolean;
}
//# sourceMappingURL=AbstractSceneObject.d.ts.map